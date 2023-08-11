using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.Data.DBOperations;
using WebApi.Models.BookModels;

namespace WebApi.Business.Application.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList();

            var viewModel = _mapper.Map<List<BooksViewModel>>(bookList);

            return viewModel;
        }
    }
}