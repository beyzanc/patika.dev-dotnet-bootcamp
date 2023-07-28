using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.TagHelpers;
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
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(g => g.Genre, o => o.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(g => g.Genre, o => o.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}