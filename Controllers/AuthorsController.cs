using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyApplicationApi.Data;
using MyApplicationApi.Dtos;
using MyApplicationApi.Helpers;
using MyApplicationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplicationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IMapper mapper;

        public AuthorsController(IAuthorRepository authorRepository, IMapper mapper)
        {
            this.authorRepository = authorRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authorsList = authorRepository.GetAll();

            /*var authors = new List<AuthorReadDTO>();

            foreach (var author in authorsList)
            {
                authors.Add(new AuthorReadDTO
                {
                    AuthorId = author.AuthorId,
                    Name = $"{author.FirstName} { author.LastName}",
                    Age = author.DOB.GetCurrentAge()
                });
            }

            return Ok(authors);*/

            return Ok(mapper.Map<IEnumerable<AuthorReadDTO>>(authorsList));
        }

        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult GetAuthor(int id)
        {
            var author = authorRepository.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<AuthorReadDTO>(author));
            // return new JsonResult(author);
        }

        [HttpPost]
        public ActionResult<AuthorReadDTO> AddAuthor(AuthorCreationDTO authorCreationDTO)
        {
            var authorEntity = mapper.Map<Author>(authorCreationDTO);
            var authorAdded = authorRepository.Create(authorEntity);
            var authorToReturn = mapper.Map<AuthorReadDTO>(authorAdded);

            return CreatedAtRoute(
                "GetAuthor", new {id = authorAdded.AuthorId}, authorToReturn
                );
        }

        //[HttpPost]
        //public IActionResult AddAuthor([FromBody] Author author)
        //{
        //    var newAuthor = authorRepository.Create(author);

        //    return Ok(newAuthor);
        //}
    }
}
