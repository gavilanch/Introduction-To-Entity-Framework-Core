using System;
using System.Collections.Generic;

namespace ExampleDBFirst.Models
{
    public partial class Merchandising
    {
        public int Id { get; set; }
        public bool Available { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public bool IsClothing { get; set; }
        public bool IsCollectionable { get; set; }

        public virtual Product IdNavigation { get; set; }
    }
}
