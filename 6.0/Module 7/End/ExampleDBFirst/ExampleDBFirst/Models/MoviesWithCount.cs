using System;
using System.Collections.Generic;

namespace ExampleDBFirst.Models
{
    public partial class MoviesWithCount
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? AmountGenres { get; set; }
        public int? AmountCinemas { get; set; }
        public int? AmountActors { get; set; }
    }
}
