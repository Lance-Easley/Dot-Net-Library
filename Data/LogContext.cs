using Microsoft.EntityFrameworkCore;

namespace DotNetLibrary.Data
{
    public class LogContext : DbContext
    {
        public LogContext(DbContextOptions<LogContext> opt) : base(opt)
        {
            
        }

        public DbSet<Log> Logs { get; set; }
        
    }
}