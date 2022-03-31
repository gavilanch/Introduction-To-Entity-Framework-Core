using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configurations
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(p => p.Name).IsRequired();

            builder.HasQueryFilter(g => !g.IsDeleted);

            builder.HasIndex(p => p.Name).IsUnique().HasFilter("IsDeleted = 'false'");

            builder.Property<DateTime>("CreatedDate").HasDefaultValueSql("GetDate()").HasColumnType("datetime2");
        }
    }
}
