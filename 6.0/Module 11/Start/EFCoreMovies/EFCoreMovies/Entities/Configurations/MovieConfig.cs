using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configurations
{
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(250).IsRequired();
            builder.Property(p => p.PosterURL).HasMaxLength(500).IsUnicode(false);

            builder.HasMany(p => p.Genres).WithMany(p => p.Movies);
               // .UsingEntity(j => j.ToTable("GenresMovies").HasData(new {MoviesId = 1, GenresId = 7}));
        }
    }
}
