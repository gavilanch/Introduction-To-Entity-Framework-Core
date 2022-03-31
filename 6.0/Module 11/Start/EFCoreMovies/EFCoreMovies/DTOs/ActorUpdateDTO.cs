using System.ComponentModel.DataAnnotations;

namespace EFCoreMovies.DTOs
{
    public class ActorUpdateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Name_Original { get; set; }
        public string Biography { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
