using AdonaPerfuma.Models;
using Microsoft.EntityFrameworkCore;

namespace AdonaPerfuma.DB
{
    public class PerfumaContext : DbContext
    {
        public PerfumaContext(DbContextOptions<PerfumaContext> options) : base(options)
        {
            
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Image { get; set; }
    }
}
