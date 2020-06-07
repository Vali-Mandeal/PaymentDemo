using System.Threading.Tasks;
using PaymentDemo.Entities;
using PaymentDemo.Models;

namespace PaymentDemo.Services.Business.Interfaces
{
    public interface IExpensivePaymentGateway
    {
        Result<Payment> Process(Payment payment);
    }
}
