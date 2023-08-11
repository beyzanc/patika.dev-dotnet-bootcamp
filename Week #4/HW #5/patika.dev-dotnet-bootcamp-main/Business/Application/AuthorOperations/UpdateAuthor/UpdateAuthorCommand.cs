using System;
using System.Linq;
using WebApi.Data.DBOperations;
using WebApi.Models.Author;
using WebApi.Models.BookModels;

namespace WebApi.Business.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int AuthorId { get; set; }
        public UpdateAuthorModel Model { get; set; }
        public UpdateAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if (author is null)
            {
                throw new InvalidOperationException("The author is not exist.");

            }

            author.BirthDate = Model.BirthDate != default ? Model.BirthDate : author.BirthDate;
            author.Name = Model.Name != default ? Model.Name : author.Name;
            author.Surname = Model.Surname != default ? Model.Surname : author.Surname;

            _dbContext.SaveChanges();
        }
    }
}
