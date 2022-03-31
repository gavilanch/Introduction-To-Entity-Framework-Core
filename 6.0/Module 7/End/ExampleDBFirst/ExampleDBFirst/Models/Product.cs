using System;
using System.Collections.Generic;

namespace ExampleDBFirst.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual Merchandising Merchandising { get; set; }
        public virtual RentableMovie RentableMovie { get; set; }
    }
}
