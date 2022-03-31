using System;
using System.Collections.Generic;

namespace ExampleDBFirst.Models
{
    public partial class CinemaOffer
    {
        public int Id { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public decimal DiscountPercentage { get; set; }
        public int CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; }
    }
}
