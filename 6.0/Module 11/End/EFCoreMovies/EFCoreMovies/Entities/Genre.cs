using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities
{
    public class Genre: AuditableEntity
    {
        public int Id { get; set; }
        //[ConcurrencyCheck]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public string Example { get; set; }
        public string Example2 { get; set; }
        public HashSet<Movie> Movies { get; set; }
        //[Timestamp]
        //public byte[] Version { get; set; }
    }
}
