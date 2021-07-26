using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using DotNetLibrary.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IO;

namespace DotNetLibrary
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;
        private readonly IMapper _mapper;
        public RequestLogMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IMapper mapper)
        {
            _next = next;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
            _mapper = mapper;
        }

        public async Task Invoke(HttpContext context, ILogRepo repo)
        {
            await LogRequest(context, repo);
            await _next(context);
        }  

        private async Task LogRequest(HttpContext context, ILogRepo repo)
        {
            context.Request.EnableBuffering();

            await using var requestStream = _recyclableMemoryStreamManager.GetStream();
            await context.Request.Body.CopyToAsync(requestStream);

            if (context.Request.Path != "/logs") {
                LogCreateDto requestLog = new LogCreateDto{
                    Method=$"{context.Request.Method}", 
                    Host=$"{context.Request.Host}",
                    Path=$"{context.Request.Path}",
                    RequestBody=$"{ReadStreamInChunks(requestStream)}",
                    Time=System.DateTime.Now
                    };

                var logModel = _mapper.Map<Log>(requestLog);

                repo.CreateLog(logModel);
                repo.SaveChanges();
            }


            context.Request.Body.Position = 0;
        }
        
        // Helper Method
        private static string ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096;

            stream.Seek(0, SeekOrigin.Begin);

            using var textWriter = new StringWriter();
            using var reader = new StreamReader(stream);

            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;

            do
            {
                readChunkLength = reader.ReadBlock(readChunk, 
                                                0, 
                                                readChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);
            } while (readChunkLength > 0);

            return textWriter.ToString();
        } 
    }

    public static class RequestResponseLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLogMiddleware>();
        }
    }
}