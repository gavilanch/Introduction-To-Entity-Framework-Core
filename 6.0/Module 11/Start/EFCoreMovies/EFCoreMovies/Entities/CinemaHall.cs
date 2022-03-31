using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities
{
    public class CinemaHall
    {
        public int Id { get; set; }
        public CinemaHallType CinemaHallType { get; set; }
        public decimal Cost { get; set; }
        public Currency Currency { get; set; }
        public int TheCinemaId { get; set; }
        [ForeignKey(nameof(TheCinemaId))]
        public Cinema Cinema { get; set; }
        public HashSet<Movie> Movies { get; set; }
    }
}
