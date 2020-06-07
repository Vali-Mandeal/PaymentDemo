using System.Collections.Generic;
using PaymentDemo.Models;

namespace PaymentDemo.Entities
{
    public class PaymentState
    {
        public int Id { get; set; }
        public PaymentStatus State { get; set; }
        public ICollection<Payment> Payments { get; set; }  
    }
}
