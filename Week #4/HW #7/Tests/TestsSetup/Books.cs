using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.DBOperations;
using WebApi.Data.Entity;

namespace Tests.TestsSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext dbContext)
        {
            dbContext.Books.AddRange(
                    new Book
                    {
                        Title = "Tehlikeli Oyunlar",
                        GenreId = 1,
                        AuthorId = 1,
                        PageCount = 400,
                        PublishDate = new DateTime(2003, 12, 12)
                    },
                    new Book
                    {
                        Title = "Embedded Microcontrollers",
                        GenreId = 2,
                        AuthorId = 2,
                        PageCount = 555,
                        PublishDate = new DateTime(1999, 10, 13)
                    },
                    new Book
                    {
                        Title = "Rubailer",
                        GenreId = 2,
                        AuthorId = 3,
                        PageCount = 540,
                        PublishDate = new DateTime(1980, 04, 14)
                    }
                );
        }
    }

}
