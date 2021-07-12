using System.Collections.Generic;
using System.Linq;
using DotNetLibrary.Models;

namespace DotNetLibrary.Data
{
    public class SqlBookRepo : IBookRepo
    {
        private readonly BookContext _context;

        public SqlBookRepo(BookContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(p => p.Id == id);
        }
    }
}