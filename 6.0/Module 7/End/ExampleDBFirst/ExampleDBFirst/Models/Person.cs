using System;
using System.Collections.Generic;

namespace ExampleDBFirst.Models
{
    public partial class Person
    {
        public Person()
        {
            MessageReceivers = new HashSet<Message>();
            MessageSenders = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Message> MessageReceivers { get; set; }
        public virtual ICollection<Message> MessageSenders { get; set; }
    }
}
