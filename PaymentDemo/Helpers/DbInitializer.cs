using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PaymentDemo.Entities;
using PaymentDemo.Models;
using PaymentDemo.Persistance;

namespace PaymentDemo.Helpers
{
    public class DbInitializer
    {
        public static void SeedData(DataContext context)
        {
            if (context.PaymentStates.Any()) return;

            context.AddRange(GetPaymentStates());
            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.PaymentStates ON");
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.PaymentStates OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }

        private static IEnumerable<PaymentState> GetPaymentStates()
        {
            return new List<PaymentState>
            {
                new PaymentState {Id = 1, State = PaymentStatus.Pending},
                new PaymentState {Id = 2, State = PaymentStatus.Processed},
                new PaymentState {Id = 3, State = PaymentStatus.Failed},
                new PaymentState {Id = 4, State = PaymentStatus.None}
            };
        }
    }
}
