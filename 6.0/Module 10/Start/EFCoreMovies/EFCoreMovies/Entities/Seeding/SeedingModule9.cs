using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Entities.Seeding
{
    public static class SeedingModule9
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var invoice1 = new Invoice() { Id = 2, CreationDate = new DateTime(2022, 1, 24) };

            var detail1 = new List<InvoiceDetail>()
    {
        new InvoiceDetail(){Id = 3, InvoiceId = invoice1.Id, Price = 350.99m},
        new InvoiceDetail(){Id = 4, InvoiceId = invoice1.Id, Price = 10},
        new InvoiceDetail(){Id = 5, InvoiceId = invoice1.Id, Price = 45.50m},
    };

            var invoice2 = new Invoice() { Id = 3, CreationDate = new DateTime(2022, 1, 24) };

            var detail2 = new List<InvoiceDetail>()
    {
        new InvoiceDetail(){Id = 6, InvoiceId = invoice2.Id, Price = 17.99m},
        new InvoiceDetail(){Id = 7, InvoiceId = invoice2.Id, Price = 14},
        new InvoiceDetail(){Id = 8, InvoiceId = invoice2.Id, Price = 45},
        new InvoiceDetail(){Id = 9, InvoiceId = invoice2.Id, Price = 100},
    };

            var invoice3 = new Invoice() { Id = 4, CreationDate = new DateTime(2022, 1, 24) };

            var detail3 = new List<InvoiceDetail>()
    {
        new InvoiceDetail(){Id = 10, InvoiceId = invoice3.Id, Price = 371},
        new InvoiceDetail(){Id = 11, InvoiceId = invoice3.Id, Price = 114.99m},
        new InvoiceDetail(){Id = 12, InvoiceId = invoice3.Id, Price = 425},
        new InvoiceDetail(){Id = 13, InvoiceId = invoice3.Id, Price = 1000},
        new InvoiceDetail(){Id = 14, InvoiceId = invoice3.Id, Price = 5},
        new InvoiceDetail(){Id = 15, InvoiceId = invoice3.Id, Price = 2.99m},
    };

            var invoice4 = new Invoice() { Id = 5, CreationDate = new DateTime(2022, 1, 24) };

            var detail4 = new List<InvoiceDetail>()
    {
        new InvoiceDetail(){Id = 16, InvoiceId = invoice4.Id, Price = 50},
    };

            modelBuilder.Entity<Invoice>().HasData(invoice1, invoice2, invoice3, invoice4);
            modelBuilder.Entity<InvoiceDetail>().HasData(detail1);
            modelBuilder.Entity<InvoiceDetail>().HasData(detail2);
            modelBuilder.Entity<InvoiceDetail>().HasData(detail3);
            modelBuilder.Entity<InvoiceDetail>().HasData(detail4);
        }
    }
}
