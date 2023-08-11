using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Data.Entity;

namespace WebApi.DBOperations.DbConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> book)
        {
            book.Property(x => x.Id).IsRequired(true).ValueGeneratedOnAdd();

            book.Property(x => x.PublishDate).IsRequired(true);
            book.Property(x => x.PageCount).IsRequired(true);
            book.Property(x => x.Title).IsRequired(true);
            book.Property(x=> x.GenreId).IsRequired(true);


        }

    }
}
