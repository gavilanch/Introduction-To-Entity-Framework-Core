using System;
using System.Collections.Generic;

namespace ExampleDBFirst.Models
{
    public partial class Movie
    {
        public Movie()
        {
            MoviesActors = new HashSet<MoviesActor>();
            CinemaHalls = new HashSet<CinemaHall>();
            Genres = new HashSet<Genre>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public bool InCinemas { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterUrl { get; set; }

        public virtual ICollection<MoviesActor> MoviesActors { get; set; }

        public virtual ICollection<CinemaHall> CinemaHalls { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
    }
}
