using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebApi.Data.DBOperations;
using WebApi.Models.Author;


namespace WebApi.Business.Application.AuthorOperations.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<AuthorViewModel> Handle()
        {
            var authorList = _dbContext.Authors.OrderBy(x => x.Id).ToList();

            var viewModel = _mapper.Map<List<AuthorViewModel>>(authorList);

            return viewModel;
        }
    }
}
