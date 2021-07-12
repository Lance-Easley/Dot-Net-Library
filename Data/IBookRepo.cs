using System.Collections.Generic;
using DotNetLibrary.Models;

namespace DotNetLibrary.Data
{
    public interface IBookRepo
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
    }
}