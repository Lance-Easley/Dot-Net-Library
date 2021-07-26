using System.Collections.Generic;

namespace DotNetLibrary.Data
{
    public interface ILogRepo
    {
        bool SaveChanges();

        IEnumerable<Log> GetAllLogs();
        Log GetLogById(int id);
        void CreateLog(Log log);
        void DeleteLog(Log log);
    }
}