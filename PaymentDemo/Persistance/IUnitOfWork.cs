using System;
using System.Threading.Tasks;
using PaymentDemo.Models;
using PaymentDemo.Persistance.Repositories.Interfaces;

namespace PaymentDemo.Persistance
{
    public interface IUnitOfWork : IDisposable
    {
        IPaymentsRepository Payments { get; }
        Task<Result> CompleteAsync();
    }
}
