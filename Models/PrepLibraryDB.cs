using DotNetLibrary.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace DotNetLibrary.Models
{
    public static class PrepLibraryDB
    {
        public static void PrepLibrary(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<BookContext>());
            }
        }

        public static void SeedData(BookContext context) 
        {
            System.Console.WriteLine("Applying Library Migrations...");

            context.Database.Migrate();
        }
    }
}