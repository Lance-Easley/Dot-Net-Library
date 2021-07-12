using System.Collections.Generic;
using DotNetLibrary.Data;
using DotNetLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetLibrary.Controllers
{
    [Route("api")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepo _repository;

        public BooksController(IBookRepo repository)    
        {
            _repository = repository;
        }

        //GET api/books
        [HttpGet("books")]
        public ActionResult <IEnumerable<Book>> GetAllBooks()
        {
            var books = _repository.GetAllBooks();

            return Ok(books);
        }

        //GET api/book/{id}
        [HttpGet("book/{id}")]
        public ActionResult <Book> GetBookById(int id)
        {
            var book = _repository.GetBookById(id);

            return Ok(book);
        }
    }
}