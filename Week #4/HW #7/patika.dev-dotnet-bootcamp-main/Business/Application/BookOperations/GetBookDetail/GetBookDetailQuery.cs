using System;
using System.Linq;
using AutoMapper;
using WebApi.Data.DBOperations;
using WebApi.Models.BookModels;

namespace WebApi.Business.Application.BookOperations.GetBookDetail
{
    public class GetByIdQuery
    {
        public BookDetailViewModel Model { get; set; }
        public int BookId { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetByIdQuery(BookStoreDbContext context, IMapper mapper)
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