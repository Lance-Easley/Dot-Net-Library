using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetLibrary.Data
{
    public class SqlLogRepo : ILogRepo
    {
        private readonly LogContext _context;

        public SqlLogRepo(LogContext context)
        {
            _context = context;
        }

        public void CreateLog(Log log)
        {
            if (log == null) {
                throw new ArgumentNullException(nameof(log));
            }

            _context.Logs.Add(log);
        }

        public void DeleteLog(Log log)
        {
            _context.Logs.Remove(log);
        }

        public IEnumerable<Log> GetAllLogs()
        {
            return _context.Logs.ToList();
        }

        public Log GetLogById(int id)
        {
            return _context.Logs.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}