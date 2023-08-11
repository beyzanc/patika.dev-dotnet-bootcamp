using System;
using System.Linq;
using WebApi.Data.DBOperations;

namespace WebApi.Business.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int GenreId { get; set; }
        public DeleteGenreCommand(BookStoreDbContext dbContext)
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

            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();
        }
    }
}
