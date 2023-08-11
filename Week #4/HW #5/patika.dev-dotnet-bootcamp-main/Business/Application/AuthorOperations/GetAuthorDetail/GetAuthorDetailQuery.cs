using AutoMapper;
using System;
using System.Linq;
using WebApi.Data.DBOperations;
using WebApi.Models.Author;
using WebApi.Models.BookModels;

namespace WebApi.Business.Application.AuthorOperations.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public AuthorDetailViewModel Model { get; set; }
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.Where(x => x.Id == AuthorId).SingleOrDefault();
            if (author is null)
            {
                throw new InvalidOperationException("Author not found.");
            }
            AuthorDetailViewModel bm = _mapper.Map<AuthorDetailViewModel>(author);
            return bm;
        }

    }
}
