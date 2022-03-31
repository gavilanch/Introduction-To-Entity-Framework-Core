using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.Entities
{
    public class CardPayment: Payment
    {
        [StringLength(4)]
        public string Last4Digits { get; set; }
    }
}
