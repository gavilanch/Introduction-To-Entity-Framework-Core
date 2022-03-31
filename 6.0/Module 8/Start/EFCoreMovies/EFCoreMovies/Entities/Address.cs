using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities
{
    [Owned]
    public class Address
    {
        public string Street { get; set; }
        public string Province { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
