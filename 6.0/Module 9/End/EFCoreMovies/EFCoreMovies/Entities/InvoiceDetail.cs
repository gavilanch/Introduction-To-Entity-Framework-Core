using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Entities
{
    public class InvoiceDetail
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string Product { get; set; }
        [Precision(18,2)]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [Precision(18,2)]
        public decimal Total { get; set; }
    }
}
