using EFCoreMovies.Entities;
using EFCoreMovies.Entities.Configurations;
using EFCoreMovies.Entities.Keyless;
using EFCoreMovies.Entities.Seeding;
using EFCoreMovies.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFCoreMovies
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IUserService userService;

        //public ApplicationDbContext()
        //{

        //}

        public ApplicationDbContext(DbContextOptions options, IUserService userService,
            IChangeTrackerEventHandler changeTrackerEventHandler) : base(options)
        {
            this.userService = userService;
            if (changeTrackerEventHandler is not null)
            {
                ChangeTracker.Tracked += changeTrackerEventHandler.TrackedHandler;
                ChangeTracker.StateChanged += changeTrackerEventHandler.StateChangeHandler;
                SavingChanges += changeTrackerEventHandler.SavingChangesHandler;
                SavedChanges += changeTrackerEventHandler.SavedChangesHandler;
                SaveChangesFailed += changeTrackerEventHandler.SaveChangesFailHandler;
            }
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("name=DefaultConnection", options =>
        //        {
        //            options.UseNetTopologySuite();
        //        });
        //    }
        //}

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
            Module6Seeding.Seed(modelBuilder);
            SomeConfiguration(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ProcessSaveChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ProcessSaveChanges()
        {
            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added && e.Entity is AuditableEntity))
            {
                var entity = item.Entity as AuditableEntity;
                entity.CreatedBy = userService.GetUserId();
                entity.ModifiedBy = userService.GetUserId();
            }

            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified && e.Entity is AuditableEntity))
            {
                var entity = item.Entity as AuditableEntity;
                entity.ModifiedBy = userService.GetUserId();
                item.Property(nameof(entity.CreatedBy)).IsModified = false;
            }
        }

        private static void SomeConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CinemaWithoutLocation>().ToSqlQuery("Select Id, Name FROM Cinemas").ToView(null);

            //modelBuilder.Entity<MovieWithCounts>().ToView("MoviesWithCounts");

            modelBuilder.Entity<MovieWithCounts>().ToSqlQuery(@"SeLeCt Id, Title,
(Select count(*) FROM GenreMovie where MoviesId = movies.Id) as AmountGenres,
(Select count(distinct moviesId) from CinemaHallMovie
	INNER JOIN CinemaHalls
	ON CinemaHalls.Id = CinemaHallMovie.CinemaHallsId
	where MoviesId = movies.Id) as AmountCinemas,
(Select count(*) from MoviesActors where MovieId = movies.Id) as AmountActors
FROM Movies");

            modelBuilder.Entity<Merchandising>().ToTable("Merchandising");
            modelBuilder.Entity<RentableMovie>().ToTable("RentableMovies");

            var movie1 = new RentableMovie()
            {
                Id = 1,
                Name = "Spider-Man",
                MovieId = 1,
                Price = 5.99m
            };

            var merch1 = new Merchandising()
            {
                Id = 2,
                Available = true,
                IsClothing = true,
                Name = "One Piece T-Shirt",
                Weight = 1,
                Volume = 1,
                Price = 11
            };

            modelBuilder.Entity<Merchandising>().HasData(merch1);
            modelBuilder.Entity<RentableMovie>().HasData(movie1);
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
        public DbSet<Person> People { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<CinemaDetail> CinemaDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
