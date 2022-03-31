using System;
using System.Collections.Generic;

namespace ExampleDBFirst.Models
{
    public partial class RentableMovie
    {
        public int Id { get; set; }
        public int MovieId { get; set; }

        public virtual Product IdNavigation { get; set; }
    }
}
