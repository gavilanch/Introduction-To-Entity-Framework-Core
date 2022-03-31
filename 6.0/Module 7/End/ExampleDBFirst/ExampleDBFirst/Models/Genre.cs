using System;
using System.Collections.Generic;

namespace ExampleDBFirst.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Example { get; set; }
        public string Example2 { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
