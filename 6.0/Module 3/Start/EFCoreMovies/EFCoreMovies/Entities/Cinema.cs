using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace EFCoreMovies.Entities
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Point Location { get; set; }
        public CinemaOffer CinemaOffer { get; set; }
        public HashSet<CinemaHall> CinemaHalls { get; set; }
    }
}
