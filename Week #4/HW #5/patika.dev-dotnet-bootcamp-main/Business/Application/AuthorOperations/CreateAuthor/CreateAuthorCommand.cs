using AutoMapper;
using System;
using System.Linq;
using WebApi.Data.DBOperations;
using WebApi.Entity;
using WebApi.Models.Author;

namespace WebApi.Business.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }

        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateAuthorCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);
         
            if (author is not null)
            {
                throw new InvalidOperationException("This author is already exist.");

            }

            var newAuthor = _mapper.Map<Author>(Model);

            _dbContext.Authors.Add(newAuthor);
            _dbContext.SaveChanges();

        }
    }
}