using System;

namespace PaymentDemo.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
        public int PremiumProviderTries { get; set; }
        public int ExpensiveProviderTries { get; set; }
        public int CheapProviderTries { get; set; }
        public int IdState { get; set; }
        public PaymentState State { get; set; }
    }   
}   
