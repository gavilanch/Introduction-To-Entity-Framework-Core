namespace EFCoreMovies.Entities.Keyless
{
    public class MovieWithCounts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AmountGenres { get; set; }
        public int AmountCinemas { get; set; }
        public int AmountActors { get; set; }
    }
}
