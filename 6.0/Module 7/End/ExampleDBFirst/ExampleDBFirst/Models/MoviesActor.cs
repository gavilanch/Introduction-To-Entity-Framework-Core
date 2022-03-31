using System;
using System.Collections.Generic;

namespace ExampleDBFirst.Models
{
    public partial class MoviesActor
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
