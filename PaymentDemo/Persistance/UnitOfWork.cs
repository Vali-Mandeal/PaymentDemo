using System;
using System.Threading.Tasks;
using PaymentDemo.Models;
using PaymentDemo.Persistance.Repositories.Interfaces;

namespace PaymentDemo.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IPaymentsRepository Payments { get; }
        public UnitOfWork(DataContext context, IPaymentsRepository payments)
        {
            _context = context;
            Payments = payments;
        }

        public async Task<Result> CompleteAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return Result.Ok();
            }
            catch (Exception e)
            {
                return Result.Fail($"Error Message: {e.Message}, Inner Exception: {e.InnerException}");
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
