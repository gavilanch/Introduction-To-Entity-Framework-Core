using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.DTOs
{
    public class GenreCreationDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
