namespace EFCoreMovies.Entities
{
    public class Merchandising: Product
    {
        public bool Available { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public bool IsClothing { get; set; }
        public bool IsCollectionable { get; set; }
    }
}
