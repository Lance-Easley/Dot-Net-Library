using System;
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
            // Environment Variables
            var server = Configuration["DBServer"] ?? "localhost";
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? "";
            var password = Configuration["DBPassword"] ?? "";
            var bookDb = Configuration["DBCatalog"] ?? "";

            services.AddDbContext<LibraryContext>(opt => opt.UseSqlServer
            ($"Server={server},{port};Initial Catalog={bookDb};User ID={user};Password={password}"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotNetLibrary", Version = "v1" });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ILibraryRepo, SqlLibraryRepo>();
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
            
            app.UseRouting();

            app.UseAuthorization();

            PrepLibraryDB.PrepLibrary(app, Configuration["DBMigrate"] == "y");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
