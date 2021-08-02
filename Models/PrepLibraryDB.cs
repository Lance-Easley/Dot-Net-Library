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
                SeedData(serviceScope.ServiceProvider.GetService<BookContext>(), doMigrations);
            }
        }

        public static void SeedData(BookContext context, bool doMigrations) 
        {
            if (doMigrations) {
                System.Console.WriteLine("Applying Library Migrations...");

                context.Database.Migrate();
            }
        }
    }
}