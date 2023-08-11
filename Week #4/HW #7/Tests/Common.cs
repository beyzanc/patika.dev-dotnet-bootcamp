using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestsSetup;
using WebApi.Business.Common;
using WebApi.Data.DBOperations;

namespace Tests
{
    public class Common
    {
        public BookStoreDbContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public Common()
        {
            var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase("BookStoreTestDb").Options;
            Context = new(options);
            Context.Database.EnsureCreated();
            Context.AddBooks();
            Context.AddAuthors();
            Context.AddGenres();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(config => { config.AddProfile<MappingProfile>(); }).CreateMapper();
        }

    }
}
