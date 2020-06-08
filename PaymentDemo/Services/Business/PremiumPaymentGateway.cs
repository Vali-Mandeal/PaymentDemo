using System.Threading.Tasks;
using PaymentDemo.Entities;
using PaymentDemo.Helpers;
using PaymentDemo.Models;
using PaymentDemo.Services.Business.Interfaces;

namespace PaymentDemo.Services.Business
{
    public class PremiumPaymentGateway : IPremiumPaymentGateway
    {
        private readonly PaymentGatewayManager _paymentGatewayManager;

        public PremiumPaymentGateway(PaymentGatewayManager paymentGatewayManager)
        {
            _paymentGatewayManager = paymentGatewayManager;
        }
        public async Task<Result<Payment>> Process(Payment payment)
        {
            payment.PremiumProviderTries++;

            return await _paymentGatewayManager.Process(payment, EnvironmentVariables.PremiumProviderEndpoint,
                "PremiumProvider");
        }
    }
}
