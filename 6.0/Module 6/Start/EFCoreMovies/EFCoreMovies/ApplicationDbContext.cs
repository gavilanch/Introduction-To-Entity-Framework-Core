using EFCoreMovies.Entities;
using EFCoreMovies.Entities.Configurations;
using EFCoreMovies.Entities.Keyless;
using EFCoreMovies.Entities.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFCoreMovies
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            Module3Seeding.Seed(modelBuilder);

            modelBuilder.Entity<CinemaWithoutLocation>().ToSqlQuery("Select Id, Name FROM Cinemas").ToView(null);

            modelBuilder.Entity<MovieWithCounts>().ToView("MoviesWithCounts");

            modelBuilder.Ignore<Address>();
            //modelBuilder.Entity<Log>().Property(p => p.Id).ValueGeneratedNever();

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(string) 
                        && property.Name.Contains("URL", StringComparison.CurrentCultureIgnoreCase))
                    {
                        property.SetIsUnicode(false);
                    }
                }
            }

        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CinemaOffer> CinemaOffers { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<MovieActor> MoviesActors { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<CinemaWithoutLocation> CinemasWithoutLocations { get; set; }
    }
}
