using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExampleDBFirst.Models
{
    public partial class EFCoreMoviesDBContext : DbContext
    {
        public EFCoreMoviesDBContext()
        {
        }

        public EFCoreMoviesDBContext(DbContextOptions<EFCoreMoviesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<CinemaHall> CinemaHalls { get; set; }
        public virtual DbSet<CinemaOffer> CinemaOffers { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Merchandising> Merchandisings { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MoviesActor> MoviesActors { get; set; }
        public virtual DbSet<MoviesWithCount> MoviesWithCounts { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<RentableMovie> RentableMovies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.Property(e => e.BillingAddressCountry)
                    .HasMaxLength(150)
                    .HasColumnName("BillingAddress_Country");

                entity.Property(e => e.BillingAddressProvince)
                    .HasMaxLength(150)
                    .HasColumnName("BillingAddress_Province");

                entity.Property(e => e.BillingAddressStreet)
                    .HasMaxLength(150)
                    .HasColumnName("BillingAddress_Street");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.HomeAddressCountry)
                    .HasMaxLength(150)
                    .HasColumnName("HomeAddress_Country");

                entity.Property(e => e.HomeAddressProvince)
                    .HasMaxLength(150)
                    .HasColumnName("HomeAddress_Province");

                entity.Property(e => e.HomeAddressStreet)
                    .HasMaxLength(150)
                    .HasColumnName("HomeAddress_Street");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.Property(e => e.CodeOfConduct).HasMaxLength(150);

                entity.Property(e => e.Country).HasMaxLength(150);

                entity.Property(e => e.History).HasMaxLength(150);

                entity.Property(e => e.Missions).HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Province).HasMaxLength(150);

                entity.Property(e => e.Street).HasMaxLength(150);

                entity.Property(e => e.Values).HasMaxLength(150);
            });

            modelBuilder.Entity<CinemaHall>(entity =>
            {
                entity.HasIndex(e => e.TheCinemaId, "IX_CinemaHalls_TheCinemaId");

                entity.Property(e => e.CinemaHallType)
                    .IsRequired()
                    .HasDefaultValueSql("(N'TwoDimensions')");

                entity.Property(e => e.Cost).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.TheCinema)
                    .WithMany(p => p.CinemaHalls)
                    .HasForeignKey(d => d.TheCinemaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasMany(d => d.Movies)
                    .WithMany(p => p.CinemaHalls)
                    .UsingEntity<Dictionary<string, object>>(
                        "CinemaHallMovie",
                        l => l.HasOne<Movie>().WithMany().HasForeignKey("MoviesId"),
                        r => r.HasOne<CinemaHall>().WithMany().HasForeignKey("CinemaHallsId"),
                        j =>
                        {
                            j.HasKey("CinemaHallsId", "MoviesId");

                            j.ToTable("CinemaHallMovie");

                            j.HasIndex(new[] { "MoviesId" }, "IX_CinemaHallMovie_MoviesId");
                        });
            });

            modelBuilder.Entity<CinemaOffer>(entity =>
            {
                entity.HasIndex(e => e.CinemaId, "IX_CinemaOffers_CinemaId")
                    .IsUnique();

                entity.Property(e => e.Begin).HasColumnType("date");

                entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.End).HasColumnType("date");

                entity.HasOne(d => d.Cinema)
                    .WithOne(p => p.CinemaOffer)
                    .HasForeignKey<CinemaOffer>(d => d.CinemaId);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasIndex(e => e.Name, "IX_Genres_Name")
                    .IsUnique()
                    .HasFilter("([IsDeleted]='false')");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Example).HasMaxLength(150);

                entity.Property(e => e.Example2).HasMaxLength(150);

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("(N'')");

                entity.HasMany(d => d.Movies)
                    .WithMany(p => p.Genres)
                    .UsingEntity<Dictionary<string, object>>(
                        "GenreMovie",
                        l => l.HasOne<Movie>().WithMany().HasForeignKey("MoviesId"),
                        r => r.HasOne<Genre>().WithMany().HasForeignKey("GenresId"),
                        j =>
                        {
                            j.HasKey("GenresId", "MoviesId");

                            j.ToTable("GenreMovie");

                            j.HasIndex(new[] { "MoviesId" }, "IX_GenreMovie_MoviesId");
                        });
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Example).HasMaxLength(150);

                entity.Property(e => e.Message).HasMaxLength(150);
            });

            modelBuilder.Entity<Merchandising>(entity =>
            {
                entity.ToTable("Merchandising");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Merchandising)
                    .HasForeignKey<Merchandising>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasIndex(e => e.ReceiverId, "IX_Messages_ReceiverId");

                entity.HasIndex(e => e.SenderId, "IX_Messages_SenderId");

                entity.Property(e => e.Content).HasMaxLength(150);

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.MessageReceivers)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.MessageSenders)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.PosterUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PosterURL");

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<MoviesActor>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.ActorId });

                entity.HasIndex(e => e.ActorId, "IX_MoviesActors_ActorId");

                entity.Property(e => e.Character).HasMaxLength(150);

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.MoviesActors)
                    .HasForeignKey(d => d.ActorId);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MoviesActors)
                    .HasForeignKey(d => d.MovieId);
            });

            modelBuilder.Entity<MoviesWithCount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MoviesWithCounts");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EmailAddress).HasMaxLength(150);

                entity.Property(e => e.Last4Digits)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PaymentDate).HasColumnType("date");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<RentableMovie>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.RentableMovie)
                    .HasForeignKey<RentableMovie>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
