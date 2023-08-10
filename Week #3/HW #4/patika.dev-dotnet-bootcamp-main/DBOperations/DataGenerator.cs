using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Data.Entity;

namespace WebApi.Data.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                    new Book
                    {
                        Title = "Don Quixote",
                        GenreId = 2,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        Title = "The Little Prince",
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 05, 23)
                    },
                    new Book
                    {
                        Title = "Star Wars series",
                        GenreId = 2,
                        PageCount = 540,
                        PublishDate = new DateTime(2002, 12, 21)
                    },
                    new Book
                    {
                        Title = "Peter Rabbit",
                        GenreId = 3,
                        PageCount = 464,
                        PublishDate = new DateTime(2009, 01, 01)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}