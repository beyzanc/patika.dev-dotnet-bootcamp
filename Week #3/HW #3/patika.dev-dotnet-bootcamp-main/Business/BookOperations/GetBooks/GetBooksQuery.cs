using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.Book;
using WebApi.Business.Common;
using WebApi.Data.DBOperations;
using WebApi.Data.Entity;

namespace WebApi.Business.BookOperations.GetBooks
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

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            
            List<BooksViewModel> viewModel = _mapper.Map<List<BooksViewModel>>(bookList);

            return viewModel;
        }
    }
}