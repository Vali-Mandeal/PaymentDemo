using System;
using Moq;
using PaymentDemo.Entities;
using PaymentDemo.Persistance;
using PaymentDemo.Services.Business;
using PaymentDemo.Services.Business.Interfaces;

namespace PaymentDemo.Tests.Unit_Tests.PaymentService
{
    public class PaymentServiceFixture : IDisposable
    {
        public IPaymentService PaymentService { get; set; }
        public PaymentServiceFixture()
        {
            var cheapPaymentGateway = new CheapPaymentGateway();
            var expensivePaymentGateway = new ExpensivePaymentGateway();
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Payments.Add(It.IsAny<Payment>()));
            PaymentService = new Services.Business.PaymentService(cheapPaymentGateway, expensivePaymentGateway, unitOfWork.Object);
        }
        public void Dispose() { }
    }
}