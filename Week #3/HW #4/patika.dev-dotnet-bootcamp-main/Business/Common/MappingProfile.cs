using AutoMapper;
using Model.Book;
using WebApi.Business.BookOperations.GetBookDetail;
using WebApi.Business.BookOperations.GetBooks;
using WebApi.Data.Entity;
using static WebApi.Business.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.Business.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            CreateMap<Book, CreateBookModel>().ReverseMap();
            CreateMap<Book, UpdateBookModel>().ReverseMap();
            CreateMap<Book, BookDetailViewModel>().ReverseMap();
            CreateMap<Book, BookDetailViewModel>().ReverseMap();


        }
    }
}