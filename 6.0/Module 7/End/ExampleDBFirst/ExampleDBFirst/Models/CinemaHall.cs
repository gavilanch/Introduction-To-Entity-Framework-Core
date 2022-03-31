using System;
using System.Collections.Generic;

namespace ExampleDBFirst.Models
{
    public partial class CinemaHall
    {
        public CinemaHall()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public decimal Cost { get; set; }
        public int TheCinemaId { get; set; }
        public string CinemaHallType { get; set; }
        public string Currency { get; set; }

        public virtual Cinema TheCinema { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
