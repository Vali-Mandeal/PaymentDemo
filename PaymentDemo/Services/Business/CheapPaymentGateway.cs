﻿using System.Threading.Tasks;
using PaymentDemo.Entities;
using PaymentDemo.Helpers;
using PaymentDemo.Models;
using PaymentDemo.Services.Business.Interfaces;

namespace PaymentDemo.Services.Business
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        private readonly PaymentGatewayManager _paymentGatewayManager;

        public CheapPaymentGateway(PaymentGatewayManager paymentGatewayManager)
        {
            _paymentGatewayManager = paymentGatewayManager;
        }

        public async Task<Result<Payment>> Process(Payment payment)
        { 
            payment.CheapProviderTries++;

            return await _paymentGatewayManager.Process(payment, EnvironmentVariables.CheapProviderEndpoint, "CheapProvider");
        }
    }
}
