using DotNetLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetLibrary.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> opt) : base(opt)
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Log> Logs { get; set; }
        
    }
}