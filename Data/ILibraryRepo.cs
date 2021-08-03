using System.Collections.Generic;
using DotNetLibrary.Models;

namespace DotNetLibrary.Data
{
    public interface ILibraryRepo
    {
        bool SaveChanges();

        // Books
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);

        // Logs
        IEnumerable<Log> GetAllLogs();
        Log GetLogById(int id);
        void CreateLog(Log log);
        void DeleteLog(Log log);
    }
}