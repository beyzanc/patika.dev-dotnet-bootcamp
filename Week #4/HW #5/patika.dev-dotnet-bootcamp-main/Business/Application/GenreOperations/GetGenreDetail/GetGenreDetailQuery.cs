using AutoMapper;
using System;
using System.Linq;
using WebApi.Data.DBOperations;
using WebApi.Models.Genre;

namespace WebApi.Business.Application.GenreOperations.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public GenreDetailViewModel Model { get; set; }
        public int GenreId { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.Where(x => x.Id == GenreId).SingleOrDefault();
            if (genre is null)
            {
                throw new InvalidOperationException("Genre not found.");
            }
            GenreDetailViewModel bm = _mapper.Map<GenreDetailViewModel>(genre);
            return bm;
        }

    }
}
