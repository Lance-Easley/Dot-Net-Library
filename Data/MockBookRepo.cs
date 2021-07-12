using System;
using System.Collections.Generic;
using DotNetLibrary.Models;

namespace DotNetLibrary.Data
{
    public class MockBookRepo : IBookRepo
    {
        public IEnumerable<Book> GetAllBooks()
        {
            var books = new List<Book>
            {
                new Book{Id=0, Title="Test1", Author="Tester1", Description="Testing1", PublishDate=new DateTime(2020, 7, 12, 9, 44, 0)},
                new Book{Id=1, Title="Test2", Author="Tester2", Description="Testing2", PublishDate=new DateTime(2020, 7, 13, 10, 45, 0)},
                new Book{Id=2, Title="Test3", Author="Tester3", Description="Testing3", PublishDate=new DateTime(2020, 7, 14, 11, 46, 0)}
            };

            return books;
        }

        public Book GetBookById(int id)
        {
            return new Book{Id=0, Title="Test", Author="Tester", Description="Testing", PublishDate=new DateTime(2020, 7, 12, 9, 44, 0)};
        }
    }
}