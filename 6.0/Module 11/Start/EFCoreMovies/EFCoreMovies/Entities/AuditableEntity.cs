namespace EFCoreMovies.Entities
{
    public abstract class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
