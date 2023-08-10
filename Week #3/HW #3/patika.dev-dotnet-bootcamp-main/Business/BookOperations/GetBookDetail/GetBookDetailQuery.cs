using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DB.DBOperations;
using Microsoft.EntityFrameworkCore;
using Model.Book;
using WebApi.Business.BookOperations.GetBooks;
using WebApi.Data.DBOperations;
using WebApi.Data.Entity;

namespace WebApi.Business.BookOperations.GetBookDetail
{
    public class GetByIdQuery
    {
        public BookDetailViewModel Model { get; set; }
        public int BookId { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetByIdQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public BookDetailViewModel Handle()
        {
            var book = _context.Books.Where(x => x.Id == BookId).SingleOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Book not found.");
            }
            BookDetailViewModel bm = _mapper.Map<BookDetailViewModel>(book);
            return bm;
        }

    }
}