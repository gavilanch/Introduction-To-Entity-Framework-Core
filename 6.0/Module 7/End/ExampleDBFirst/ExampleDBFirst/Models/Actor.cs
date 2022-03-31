using System;
using System.Collections.Generic;

namespace ExampleDBFirst.Models
{
    public partial class Actor
    {
        public Actor()
        {
            MoviesActors = new HashSet<MoviesActor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BillingAddressCountry { get; set; }
        public string BillingAddressProvince { get; set; }
        public string BillingAddressStreet { get; set; }
        public string HomeAddressCountry { get; set; }
        public string HomeAddressProvince { get; set; }
        public string HomeAddressStreet { get; set; }

        public virtual ICollection<MoviesActor> MoviesActors { get; set; }
    }
}
