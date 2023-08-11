using System;
using System.Linq;
using WebApi.Data.DBOperations;
using WebApi.Models.Genre;

namespace WebApi.Business.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }
        public UpdateGenreCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);

            if (genre is null)
            {
                throw new InvalidOperationException("The genre is not exist.");

            }

            genre.IsActive = Model.IsActive != default ? Model.IsActive : genre.IsActive;
            genre.Name = Model.Name != default ? Model.Name : genre.Name;

            _dbContext.SaveChanges();
        }
    }
}
