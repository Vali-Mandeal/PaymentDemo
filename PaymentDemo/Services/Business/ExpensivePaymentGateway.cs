using System;
using System.Threading.Tasks;
using PaymentDemo.Entities;
using PaymentDemo.Models;
using PaymentDemo.Services.Business.Interfaces;

namespace PaymentDemo.Services.Business
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        public Result<Payment> Process(Payment payment)
        {
            // external payment boilerplate (simulate integration of external service)
            // assume processing fails sometimes
            var random = new Random().Next();

            payment.ExpensiveProviderTries++;

            if (random % 2 ==0)
            {
                payment.IdState = (int)PaymentStatus.Processed;
                return Result<Payment>.Ok(payment);
            }

            payment.IdState = (int) PaymentStatus.Failed;
            return Result<Payment>.Fail("Payment Failed", payment);

        }
    }
}
