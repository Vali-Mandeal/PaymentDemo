using PaymentDemo.Entities;
using PaymentDemo.Persistance.Repositories.Interfaces;

namespace PaymentDemo.Persistance.Repositories
{
    public class PaymentsRepository : Repository<Payment>, IPaymentsRepository
    {
        public PaymentsRepository(DataContext context)
        :base(context)
        {
        }   
    }
}
