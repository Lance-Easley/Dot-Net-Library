using System;
using System.Collections.Generic;
using DotNetLibrary.Models;

namespace DotNetLibrary.Data
{
    public class MockBookRepo : IBookRepo
    {
        public void CreateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var books = new List<Book>
            {
                new Book{Id=0, Title="Test1", Author="Tester1", Description="Testing1", PublishDate="7/12/2021"},
                new Book{Id=1, Title="Test2", Author="Tester2", Description="Testing2", PublishDate="7/13/2021"},
                new Book{Id=2, Title="Test3", Author="Tester3", Description="Testing3", PublishDate="7/14/2021"}
            };

            return books;
        }

        public Book GetBookById(int id)
        {
            return new Book{Id=0, Title="Test", Author="Tester", Description="Testing", PublishDate="7/12/2021"};
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}