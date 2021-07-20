using System.Collections.Generic;
using AutoMapper;
using DotNetLibrary.Data;
using DotNetLibrary.Dtos;
using DotNetLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace DotNetLibrary.Controllers
{
    [EnableCors("AllowAllHeaders")]
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

        //PUT api/book/{id}
        [HttpPut("book/{id}")]
        public ActionResult UpdateBook(int id, BookUpdateDto bookUpdateDto)
        {
            var bookModelFromRepo = _repository.GetBookById(id);

            if (bookModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(bookUpdateDto, bookModelFromRepo);

            _repository.UpdateBook(bookModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/book/{id}
        [HttpDelete("book/{id}")]
        public ActionResult DeleteBook(int id)
        {
            var bookModelFromRepo = _repository.GetBookById(id);

            if (bookModelFromRepo == null)
            {
                return NotFound();
            } 

            _repository.DeleteBook(bookModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}