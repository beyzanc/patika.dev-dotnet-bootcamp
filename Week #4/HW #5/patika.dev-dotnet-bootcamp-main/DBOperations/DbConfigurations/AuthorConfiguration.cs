using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Data.Entity;
using WebApi.Entity;

namespace WebApi.DBOperations.DbConfigurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> author)
        {

            author.Property(a => a.Id).IsRequired(true).ValueGeneratedOnAdd();

            author.Property(a => a.Name).IsRequired(true);
            author.Property(a => a.Surname).IsRequired(true);
            author.Property(a => a.BirthDate).IsRequired(true);


            author.HasMany(a => a.Books)
                .WithOne(x=> x.Author)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
