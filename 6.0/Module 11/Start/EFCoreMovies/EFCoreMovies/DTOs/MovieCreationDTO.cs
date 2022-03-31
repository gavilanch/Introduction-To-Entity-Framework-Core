namespace EFCoreMovies.DTOs
{
    public class MovieCreationDTO
    {
        public string Title { get; set; }
        public bool InCinemas { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<int> GenresIds { get; set; }
        public List<int> CinemaHallsIds { get; set; }
        public List<MovieActorCreationDTO> MoviesActors { get; set; }
    }
}
