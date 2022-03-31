using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configurations
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable(name: "Genres", options =>
            {
                options.IsTemporal();
            });

            builder.Property<DateTime>("PeriodStart").HasColumnType("datetime2");
            builder.Property<DateTime>("PeriodEnd").HasColumnType("datetime2");

            builder.Property(p => p.Name).IsRequired();

            //builder.Property(p => p.Version).IsRowVersion();

            builder.HasQueryFilter(g => !g.IsDeleted);

            builder.HasIndex(p => p.Name).IsUnique().HasFilter("IsDeleted = 'false'");

            builder.Property<DateTime>("CreatedDate").HasDefaultValueSql("GetDate()").HasColumnType("datetime2");
        }
    }
}
