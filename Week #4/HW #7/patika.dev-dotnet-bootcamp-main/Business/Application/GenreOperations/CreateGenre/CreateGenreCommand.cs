using AutoMapper;
using System;
using System.Linq;
using WebApi.Data.DBOperations;
using WebApi.Data.Entity;
using WebApi.Entity;
using WebApi.Models.BookModels;
using WebApi.Models.Genre;

namespace WebApi.Business.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }

        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateGenreCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if (genre is not null)
            {
                throw new InvalidOperationException("This genre is already exist.");
            }

            genre = _mapper.Map<Genre>(Model);

            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();

        }


    }
}
