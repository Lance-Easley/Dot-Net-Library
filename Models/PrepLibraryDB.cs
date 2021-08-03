using DotNetLibrary.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace DotNetLibrary.Models
{
    public static class PrepLibraryDB
    {
        public static void PrepLibrary(IApplicationBuilder app, bool doMigrations)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<LibraryContext>(), doMigrations);
            }
        }

        public static void SeedData(LibraryContext context, bool doMigrations) 
        {
            if (doMigrations) {
                System.Console.WriteLine("Applying Library Migrations...");
                System.Console.WriteLine("Application is likely to fail after migrations.");
                System.Console.WriteLine("Be sure to relaunch without migrating to run.");

                context.Database.Migrate();
            }
        }
    }
}