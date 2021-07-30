using DotNetLibrary.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace DotNetLibrary.Models
{
    public static class PrepLogDB
    {
        public static void PrepLog(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<LogContext>());
            }
        }

        public static void SeedData(LogContext context) 
        {
            System.Console.WriteLine("Applying Logs Migrations...");

            context.Database.Migrate();
        }
    }
}