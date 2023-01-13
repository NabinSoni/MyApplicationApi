using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApplicationApi.Data;
using MyApplicationApi.Dtos;
using MyApplicationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplicationApi.Controllers
{
    [Route("api/authors/{authorId}/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository repository;
        private readonly IMapper mapper;

        public BooksController(IBookRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookReadDTO>> GetBookByAuthor(int authorId)
        {
            var books = repository.GetBooksByAuthor(authorId);
            if(books.Count() == 0)
            {
                return NotFound();
            }
            return Ok(mapper.Map<IEnumerable<BookReadDTO>>(books));
        }

        [HttpGet("{bookId}", Name = "GetCourseForAuthor")]
        public ActionResult<BookReadDTO> GetBookForAuthor(int authorId, int bookId)
        {
            var book = repository.GetBook(authorId, bookId);

            if(book == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<BookReadDTO>(book));
        }

        [HttpPost]
        public ActionResult<BookReadDTO> CreationBookForAuthor(int authorId, BookCreationDTO book)
        {
            var bookEntity = mapper.Map<Book>(book);
            repository.AddBook(authorId, bookEntity);
            var bookToReturn = mapper.Map<BookReadDTO>(bookEntity);

            return CreatedAtRoute("GetCourseForAuthor", new { authorId = authorId, bookId = bookToReturn.BookId }, bookToReturn);
        }

        //[HttpGet]
        //public List<Book> GetBooks()
        //{
        //    return repository.GetBooks();            
        //}

        //[HttpGet("{id}")]
        //public ActionResult<Book> GetBook(int id)
        //{
        //    var book = repository.GetBook(id);
        //    if(book == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(book);
        //}

        //[HttpPost]
        //public Book PostBook([FromBody] Book book)
        //{
        //    return repository.AddBook(book);
        //}
    }
}
