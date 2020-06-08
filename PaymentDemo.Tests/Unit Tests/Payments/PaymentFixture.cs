using System;
using AutoMapper;
using Moq;
using PaymentDemo.Controllers;
using PaymentDemo.Dtos;
using PaymentDemo.Entities;
using PaymentDemo.Helpers.MapperProfiles;
using PaymentDemo.Models;
using PaymentDemo.Services.Business.Interfaces;
using PaymentDemo.Services.Validators;

namespace PaymentDemo.Tests.Unit_Tests.Payments
{
    public class PaymentFixture : IDisposable
    {
        public PaymentsController Controller { get; set; }

        public PaymentFixture()
        {
            var paymentService = new Mock<IPaymentService>();
            paymentService.Setup(service => service.Process(It.IsAny<Payment>())).ReturnsAsync(Result<Payment>.Ok(null));

            var config =  new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PaymentProfile>();
                cfg.CreateMap<PaymentDto, Payment>();
            });
            var mapper = config.CreateMapper();

            var validator = new PaymentValidator();

            Controller = new PaymentsController(paymentService.Object, mapper, validator);
        }

        public void Dispose() {}
    }
}