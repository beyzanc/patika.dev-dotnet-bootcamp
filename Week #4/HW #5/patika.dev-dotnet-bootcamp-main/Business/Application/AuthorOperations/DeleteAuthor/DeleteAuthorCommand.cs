using System;
using System.Linq;
using WebApi.Data.DBOperations;

namespace WebApi.Business.Application.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int AuthorId { get; set; }
        public DeleteAuthorCommand(BookStoreDbContext dbContext)
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

            var books = author.Books;

            if (books is not null) 
            {
                throw new InvalidOperationException("It can not be deleted the author who has the book.");
            
            }

            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }
    }
}
