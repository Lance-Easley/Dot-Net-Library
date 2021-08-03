using System;
using System.Collections.Generic;
using System.Linq;
using DotNetLibrary.Models;

namespace DotNetLibrary.Data
{
    public class SqlLibraryRepo : ILibraryRepo
    {
        private readonly LibraryContext _context;

        public SqlLibraryRepo(LibraryContext context)
        {
            _context = context;
        }

        // Books
        public void CreateBook(Book book)
        {
            if (book == null) {
                throw new ArgumentNullException(nameof(book));
            }

            _context.Books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateBook(Book book)
        {
            // Nothing
        }

        // Logs
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
    }
}