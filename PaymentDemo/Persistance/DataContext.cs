using Microsoft.EntityFrameworkCore;
using PaymentDemo.Entities;

namespace PaymentDemo.Persistance
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentState> PaymentStates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Payment>()
                .Property(e => e.CreditCardNumber)
                .IsRequired();

            modelBuilder.Entity<Payment>()
                .Property(e => e.CardHolder)
                .IsRequired();

            modelBuilder.Entity<Payment>()
                .Property(e => e.ExpirationDate)
                .IsRequired();

            modelBuilder.Entity<Payment>()
                .Property(e => e.SecurityCode)
                .HasMaxLength(3);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Amount)
                .IsRequired()
                .HasColumnType("decimal(19,4)");

            modelBuilder.Entity<Payment>()
                .HasOne(e => e.State)
                .WithMany(s => s.Payments)
                .HasForeignKey(e => e.IdState);
        }
    }
}   
