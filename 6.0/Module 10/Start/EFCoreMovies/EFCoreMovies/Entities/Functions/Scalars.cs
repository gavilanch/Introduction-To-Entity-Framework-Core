using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Entities.Functions
{
    public static class Scalars
    {
        public static void RegisterFunctions(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(() => InvoiceDetailAverage(0));
        }

        public static decimal InvoiceDetailAverage(int invoiceId)
        {
            return 0;
        }
       
    }
}
