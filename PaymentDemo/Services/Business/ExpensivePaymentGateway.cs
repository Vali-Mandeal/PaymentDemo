using System.Threading.Tasks;
using PaymentDemo.Entities;
using PaymentDemo.Helpers;
using PaymentDemo.Models;
using PaymentDemo.Services.Business.Interfaces;

namespace PaymentDemo.Services.Business
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        private readonly PaymentGatewayManager _paymentGatewayManager;

        public ExpensivePaymentGateway(PaymentGatewayManager paymentGatewayManager)
        {
            _paymentGatewayManager = paymentGatewayManager;
        }

        public async Task<Result<Payment>> Process(Payment payment)
        {
            payment.ExpensiveProviderTries++;

            return await _paymentGatewayManager.Process(payment, EnvironmentVariables.ExpensiveProviderEndpoint,
                "ExpensiveProvider");
        }
    }
}
