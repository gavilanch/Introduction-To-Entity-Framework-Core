using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities
{
    //[NotMapped]
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
    }
}
