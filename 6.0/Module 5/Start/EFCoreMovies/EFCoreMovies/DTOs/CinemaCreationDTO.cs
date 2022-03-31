namespace EFCoreMovies.DTOs
{
    public class CinemaCreationDTO
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public CinemaOfferCreationDTO CinemaOffer { get; set; }
        public CinemaHallCreationDTO[] CinemaHalls { get; set; }
    }
}
