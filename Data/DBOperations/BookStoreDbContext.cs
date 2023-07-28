using Microsoft.EntityFrameworkCore;
using WebApi.Data.Entity;

namespace WebApi.Data.DBOperations
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }



    }
}
