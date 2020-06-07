using System.Threading.Tasks;
using PaymentDemo.Entities;
using PaymentDemo.Models;

namespace PaymentDemo.Services.Business.Interfaces
{
    public interface IPaymentService
    {
        Task<Result<Payment>> Process(Payment payment);
    }   
}
