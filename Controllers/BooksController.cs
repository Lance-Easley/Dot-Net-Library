using System.Collections.Generic;
using AutoMapper;
using DotNetLibrary.Data;
using DotNetLibrary.Dtos;
using DotNetLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetLibrary.Controllers
{
    [Route("api")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepo _repository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepo repository, IMapper mapper)    
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/books
        [HttpGet("books")]
        public ActionResult <IEnumerable<BookReadDto>> GetAllBooks()
        {
            var books = _repository.GetAllBooks();

            return Ok(_mapper.Map<IEnumerable<BookReadDto>>(books));
        }

        //GET api/book/{id}
        [HttpGet("book/{id}", Name="GetBookById")]
        public ActionResult <BookReadDto> GetBookById(int id)
        {
            var book = _repository.GetBookById(id);

            if (book != null) {
                return Ok(_mapper.Map<BookReadDto>(book));
            }

            return NotFound();
        }

        //POST api/book
        [HttpPost("book")]
        public ActionResult <BookReadDto> CreateBook(BookCreateDto bookCreateDto)
        {
            var bookModel = _mapper.Map<Book>(bookCreateDto);

            _repository.CreateBook(bookModel);
            _repository.SaveChanges();

            var bookReadDto = _mapper.Map<BookReadDto>(bookModel);

            return CreatedAtRoute(nameof(GetBookById), new {Id = bookReadDto.Id}, bookReadDto);
        }
    }
}