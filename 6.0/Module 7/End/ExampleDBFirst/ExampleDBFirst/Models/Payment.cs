using System;
using System.Collections.Generic;

namespace ExampleDBFirst.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentType { get; set; }
        public string Last4Digits { get; set; }
        public string EmailAddress { get; set; }
    }
}
