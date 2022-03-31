using System;
using System.Collections.Generic;

namespace ExampleDBFirst.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        public virtual Person Receiver { get; set; }
        public virtual Person Sender { get; set; }
    }
}
