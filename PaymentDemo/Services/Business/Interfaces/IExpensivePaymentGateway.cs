﻿using System.Threading.Tasks;
using PaymentDemo.Entities;
using PaymentDemo.Models;

namespace PaymentDemo.Services.Business.Interfaces
{
    public interface IExpensivePaymentGateway
    {
        Task<Result<Payment>> Process(Payment payment);
    }
}
