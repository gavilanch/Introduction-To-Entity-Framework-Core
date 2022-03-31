using System;
using System.Collections.Generic;

namespace ExampleDBFirst.Models
{
    public partial class Log
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string Example { get; set; }
    }
}
