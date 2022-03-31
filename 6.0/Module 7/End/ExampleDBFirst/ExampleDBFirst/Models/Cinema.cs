using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace ExampleDBFirst.Models
{
    public partial class Cinema
    {
        public Cinema()
        {
            CinemaHalls = new HashSet<CinemaHall>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Geometry Location { get; set; }
        public string CodeOfConduct { get; set; }
        public string History { get; set; }
        public string Missions { get; set; }
        public string Values { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string Street { get; set; }

        public virtual CinemaOffer CinemaOffer { get; set; }
        public virtual ICollection<CinemaHall> CinemaHalls { get; set; }
    }
}
