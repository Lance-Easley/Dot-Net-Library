using System;
using System.Collections.Generic;
using DotNetLibrary.Data;
using DotNetLibrary.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DotNetLibrary
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var server = Configuration["DBServer"] ?? "ms-sql-server";
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? "sa";
            var password = Configuration["DBPassword"] ?? "CoreLogicProjectSQL5267";
            var bookDb = Configuration["DBBooks"] ?? "LibraryDB";
            var logDb = Configuration["DBLogs"] ?? "LogsDB";

            services.AddDbContext<BookContext>(opt => opt.UseSqlServer
            ($"Server={server},{port};Initial Catalog={bookDb};User ID={user};Password={password}"));

            services.AddDbContext<LogContext>(opt => opt.UseSqlServer
            ($"Server={server},{port};Initial Catalog={logDb};User ID={user};Password={password}"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotNetLibrary", Version = "v1" });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IBookRepo, SqlBookRepo>();
            services.AddScoped<ILogRepo, SqlLogRepo>();

            services.AddCors(options =>
                {
                    options.AddPolicy("AllowAllHeaders",
                            builder =>
                        {
                                builder.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                            });
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotNetLibrary v1"));
            }

            app.UseDefaultFiles();
            
            app.UseStaticFiles();

            app.UseRequestResponseLogging();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowAllHeaders");

            app.UseAuthorization();

            PrepLibraryDB.PrepLibrary(app, Configuration["DBMigrate"] == "y");
            PrepLogDB.PrepLog(app, Configuration["DBMigrate"] == "y");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
