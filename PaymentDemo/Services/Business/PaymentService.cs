using System.Threading.Tasks;
using PaymentDemo.Entities;
using PaymentDemo.Models;
using PaymentDemo.Persistance;
using PaymentDemo.Services.Business.Interfaces;

namespace PaymentDemo.Services.Business
{
    public class PaymentService : IPaymentService
    {
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(ICheapPaymentGateway cheapPaymentGateway, 
            IExpensivePaymentGateway expensivePaymentGateway,
            IUnitOfWork unitOfWork)
        {
            _cheapPaymentGateway = cheapPaymentGateway;
            _expensivePaymentGateway = expensivePaymentGateway;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Payment>> Process(Payment payment)
        {
            Result<Payment> processingResult = null;

            if (payment.Amount <= 20)
            {
                processingResult = _cheapPaymentGateway.Process(payment);
                payment = processingResult.Value;
            }
            else if(payment.Amount > 20 && payment.Amount < 500)
            {
                processingResult = _expensivePaymentGateway.Process(payment);
                payment = processingResult.Value;

                if (processingResult.IsFailed)
                {
                    processingResult = _cheapPaymentGateway.Process(payment);
                    payment = processingResult.Value;
                }
            }
            else
            {
                while (payment.ExpensiveProviderTries < 3)
                {
                    processingResult = _expensivePaymentGateway.Process(payment);
                    if (processingResult.IsSuccessful) break;
                }
                payment = processingResult?.Value;
            }

            _unitOfWork.Payments.Add(payment);
            await _unitOfWork.CompleteAsync();

            return processingResult != null && processingResult.IsSuccessful ? Result<Payment>.Ok(payment) : Result<Payment>.Fail(processingResult?.Error, payment);
        }
    }
}
