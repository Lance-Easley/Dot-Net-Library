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
                System.Console.WriteLine("Application is known to fail after migrations.");
                System.Console.WriteLine("It is advised to only migrate when moving to a new or cleared database.");

                context.Database.Migrate();
            }
        }
    }
}