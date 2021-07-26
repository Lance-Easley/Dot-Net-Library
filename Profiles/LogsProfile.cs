using AutoMapper;
using DotNetLibrary.Data;

namespace DotNetLibrary.Profiles
{
    public class LogsProfile : Profile
    {
        public LogsProfile()
        {
            CreateMap<Log, LogReadDto>();
            CreateMap<LogCreateDto, Log>();
        }
    }
}