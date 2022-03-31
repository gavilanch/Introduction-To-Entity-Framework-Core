using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configurations
{
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        { 
            builder.ToTable(name: "Invoices", options =>
            {
                options.IsTemporal(t =>
                {
                    t.HasPeriodStart("From");
                    t.HasPeriodEnd("To");
                    t.UseHistoryTable(name: "InvoicesHistoryTbl");
                });
            });

            builder.Property<DateTime>("From").HasColumnType("datetime2");
            builder.Property<DateTime>("To").HasColumnType("datetime2");

            builder.HasMany(typeof(InvoiceDetail)).WithOne();

            builder.Property(p => p.InvoiceNumber)
                .HasDefaultValueSql("NEXT VALUE FOR invoice.InvoiceNumber");
        }
    }
}
