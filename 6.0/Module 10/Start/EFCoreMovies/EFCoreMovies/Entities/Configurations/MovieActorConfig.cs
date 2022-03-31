using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configurations
{
    public class MovieActorConfig : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasKey(p => new { p.MovieId, p.ActorId });

            builder.HasOne(p => p.Actor).WithMany(p => p.MoviesActors).HasForeignKey(p => p.ActorId);

            builder.HasOne(p => p.Movie).WithMany(p => p.MoviesActors).HasForeignKey(p => p.MovieId);
        }
    }
}
