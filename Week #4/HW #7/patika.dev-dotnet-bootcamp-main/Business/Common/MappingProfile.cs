using AutoMapper;
using WebApi.Data.Entity;
using WebApi.Entity;
using WebApi.Models.Author;
using WebApi.Models.BookModels;
using WebApi.Models.Genre;
using static WebApi.Business.Application.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.Business.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            CreateMap<Book, CreateBookModel>().ReverseMap();
            CreateMap<Book, Models.BookModels.UpdateBookModel>().ReverseMap();
            CreateMap<Book, BookDetailViewModel>().ReverseMap();
            CreateMap<Book, BooksViewModel>().ReverseMap();


            CreateMap<Author, CreateAuthorModel>().ReverseMap();
            CreateMap<Author, Models.Author.UpdateAuthorModel>().ReverseMap();
            CreateMap<Author, AuthorDetailViewModel>().ReverseMap();
            CreateMap<Author, BooksViewModel>().ReverseMap();

            CreateMap<Genre, CreateGenreModel>().ReverseMap();
            CreateMap<Genre, UpdateGenreModel>().ReverseMap();
            CreateMap<Genre, GenreDetailViewModel>().ReverseMap();
            CreateMap<Genre, GenresViewModel>().ReverseMap();


        }
    }
}