using System.Collections.Generic;
using DotNetLibrary.Models;

namespace DotNetLibrary.Data
{
    public interface IBookRepo
    {
        bool SaveChanges();

        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void CreateBook(Book book);
    }
}