using PaymentDemo.Entities;
using PaymentDemo.Models;
using PaymentDemo.Services.Business.Interfaces;

namespace PaymentDemo.Services.Business
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        public Result<Payment> Process(Payment payment)
        {
            // external payment boilerplate (simulate integration of external service)
            payment.IdState = (int) PaymentStatus.Processed;
            payment.CheapProviderTries++;
            return Result<Payment>.Ok(payment);
        }
    }
}
