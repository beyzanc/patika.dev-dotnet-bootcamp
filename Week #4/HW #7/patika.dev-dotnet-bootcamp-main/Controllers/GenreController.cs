using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.Application.GenreOperations.CreateGenre;
using WebApi.Business.Application.GenreOperations.DeleteGenre;
using WebApi.Business.Application.GenreOperations.GetGenreDetail;
using WebApi.Business.Application.GenreOperations.GetGenres;
using WebApi.Business.Application.GenreOperations.UpdateGenre;
using WebApi.Business.Validators.Genre;
using WebApi.Data.DBOperations;
using WebApi.Models.Genre;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);

        }


        [HttpGet("{id}")]
        public IActionResult GetGenreById(int id)
        {
            GenreDetailViewModel result;
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            GetGenreByIdValidator validator = new GetGenreByIdValidator();
            query.GenreId = id;
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);

        }


        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = newGenre;
            command.Handle();
            return Ok("Genre created successfully!");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updatedGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.Model = updatedGenre;
            command.GenreId = id;
            UpdateGenreValidator validator = new UpdateGenreValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok("Genre updated successfully!");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;
            DeleteGenreValidator validator = new DeleteGenreValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Genre deleted successfully!");
        }


    }
}
