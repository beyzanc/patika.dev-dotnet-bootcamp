using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Entity;

namespace WebApi.DBOperations.DbConfigurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> genre)
        {

            genre.Property(g => g.Id).IsRequired(true).ValueGeneratedOnAdd();

            genre.Property(g => g.Name).IsRequired(true);
            genre.Property(g => g.IsActive).IsRequired(true);

            genre.HasMany(g => g.Books)
                .WithOne(g => g.Genre)
                .HasForeignKey(g => g.GenreId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
