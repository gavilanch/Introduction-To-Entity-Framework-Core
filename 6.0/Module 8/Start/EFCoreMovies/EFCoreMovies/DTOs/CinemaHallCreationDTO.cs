using EFCoreMovies.Entities;

namespace EFCoreMovies.DTOs
{
    public class CinemaHallCreationDTO
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public CinemaHallType CinemaHallType { get; set; }
    }
}
