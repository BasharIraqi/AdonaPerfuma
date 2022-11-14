using AdonaPerfuma.Models;
using Microsoft.EntityFrameworkCore;

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

            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, FirstName = "Director", LastName = "Perfuma", Email = "Director@perfuma.com", Password = "Pddd2022!", ConfirmPassword = "Pddd2022!", Role = Roles.Admin },
                new User() { Id = 2, Email = "Manager1@perfuma.com", FirstName = "Manager 1", LastName = "Perfuma", Password = "Pmmm1111@", ConfirmPassword = "Pmmm1111@", Role = Roles.Manager },
                new User() { Id = 3, Email = "Manager2@perfuma.com", FirstName = "Manager 2", LastName = "Perfuma", Password = "Pmmm2222@", ConfirmPassword = "Pmmm2222@", Role = Roles.Manager },
                new User() { Id = 4, Email = "Manager3@perfuma.com", FirstName = "Manager 3", LastName = "Perfuma", Password = "Pmmm3333@", ConfirmPassword = "Pmmm3333@", Role = Roles.Manager },
                new User() { Id = 5, Email = "General1@perfuma.com", FirstName = "Employee 1", LastName = "Perfuma", Password = "Pggg111$", ConfirmPassword = "Pggg111$", Role = Roles.General },
                new User() { Id = 6, Email = "General2@perfuma.com", FirstName = "Employee 2", LastName = "Perfuma", Password = "Pggg222$", ConfirmPassword = "Pggg222$", Role = Roles.General },
                new User() { Id = 7, Email = "General3@perfuma.com", FirstName = "Employee 3", LastName = "Perfuma", Password = "Pggg333$", ConfirmPassword = "Pggg333$", Role = Roles.General }
                );
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }

    }

}
