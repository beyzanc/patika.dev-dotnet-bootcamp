using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebApi.Data.DBOperations;
using WebApi.Models.Genre;

namespace WebApi.Business.Application.GenreOperations.GetGenres
{
    public class GetGenresQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetGenresQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<GenresViewModel> Handle()
        {
            var genreList = _dbContext.Genres.OrderBy(x => x.Id).ToList();

            List<GenresViewModel> viewModel = _mapper.Map<List<GenresViewModel>>(genreList);

            return viewModel;
        }
    }
}
