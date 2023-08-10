using DB.DBOperations;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Entity;

namespace WebApi.Data.DBOperations
{
    public class BookStoreDbContext : DbContext, IBookStoreDbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


    }
}
