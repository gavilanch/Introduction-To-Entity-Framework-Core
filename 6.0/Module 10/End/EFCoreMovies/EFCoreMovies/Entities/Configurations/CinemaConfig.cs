using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configurations
{
    public class CinemaConfig : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.Property(p => p.Name).IsRequired();

            builder.HasOne(c => c.CinemaOffer).WithOne().HasForeignKey<CinemaOffer>(co => co.CinemaId);

            builder.HasMany(c => c.CinemaHalls).WithOne(ch => ch.Cinema)
                .HasForeignKey(ch => ch.TheCinemaId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.CinemaDetail).WithOne(c => c.Cinema).HasForeignKey<CinemaDetail>(cd => cd.Id);

            builder.OwnsOne(c => c.Address, add =>
            {
                add.Property(p => p.Street).HasColumnName("Street");
                add.Property(p => p.Province).HasColumnName("Province");
                add.Property(p => p.Country).HasColumnName("Country");
            });
        }
    }
}
