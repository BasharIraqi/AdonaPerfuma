using AdonaPerfuma.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace AdonaPerfuma.DB
{
    public class PerfumaContext : DbContext
    {
        public PerfumaContext(DbContextOptions<PerfumaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
            .HasMany(o => o.Products)
            .WithMany(p => p.Orders)
            .UsingEntity<OrderProduct>(
                j => j
                    .HasOne(op => op.Product)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(op => op.ProductBarcode),
                j => j
                    .HasOne(op => op.Order)
                    .WithMany(o => o.OrderProducts)
                    .HasForeignKey(op => op.OrderId),
                j =>
                {
                    j.HasKey(op => new { op.OrderId, op.ProductBarcode });
                });
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users {get; set;}
        public DbSet<OrderProduct> OrderProduct { get; set; }

    }

}
