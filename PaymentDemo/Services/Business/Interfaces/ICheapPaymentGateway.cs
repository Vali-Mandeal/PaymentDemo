﻿using System.Threading.Tasks;
using PaymentDemo.Entities;
using PaymentDemo.Models;

namespace PaymentDemo.Services.Business.Interfaces
{
    public interface ICheapPaymentGateway
    {
        Result<Payment> Process(Payment payment);
    }
}