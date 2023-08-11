using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.Application.AuthorOperations.CreateAuthor;
using WebApi.Business.Application.AuthorOperations.DeleteAuthor;
using WebApi.Business.Application.AuthorOperations.GetAuthorDetail;
using WebApi.Business.Application.AuthorOperations.GetAuthors;
using WebApi.Business.Application.AuthorOperations.UpdateAuthor;
using WebApi.Business.Validators.Author;
using WebApi.Data.DBOperations;
using WebApi.Models.Author;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);

        }


        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            AuthorDetailViewModel result;
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
            GetAuthorByIdValidator validator = new GetAuthorByIdValidator();
            query.AuthorId = id;
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);

        }


        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = newAuthor;
            command.Handle();
            return Ok("Author created successfully!");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updatedAuthor)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.Model = updatedAuthor;
            command.AuthorId = id;
            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok("Author updated successfully!");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;
            DeleteAuthorValidator validator = new DeleteAuthorValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Author deleted successfully!");
        }


    }
}
