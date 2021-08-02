using DotNetLibrary.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace DotNetLibrary.Models
{
    public static class PrepLogDB
    {
        public static void PrepLog(IApplicationBuilder app, bool doMigrations)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<LogContext>(), doMigrations);
            }
        }

        public static void SeedData(LogContext context, bool doMigrations) 
        {
            if (doMigrations) {
                System.Console.WriteLine("Applying Logs Migrations...");

                context.Database.Migrate();
            }
        }
    }
}