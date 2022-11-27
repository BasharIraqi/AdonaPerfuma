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

            modelBuilder.Entity<BankAccount>().HasData(
                 new { AccountNumber = 777777, BranchNumber = 12, FirstName = "bashar", LastName = "iraqi", Name = BankCompany.Boalim, OwnerId = 999999999 });

            modelBuilder.Entity<User>().HasData(
                 new { Id = 7, Email = "Director@perfuma.com", Password = "Pddd2022!", ConfirmPassword = "Pddd2022!", Role = Roles.Admin, FirstName = "Bashar", LastName = "Iraqi" });

            modelBuilder.Entity<Address>().HasData(
                 new { Id = 1, City = "tira", Country = "israel", HouseNumber = 40, PostalCode = 4491500, Street = "el zahra" });


            modelBuilder.Entity<Employee>().HasData(
                 new
                 {
                     Id = 999999999,
                     FirstName = "Bashar",
                     LastName = "Iraqi",
                     Age = 23.5,
                     Email = "bashar.oroq@gmail.com",
                     PhoneNumber = "0587589333",
                     BirthDay = "25",
                     BirthMonth = "7",
                     BirthYear = "1999",
                     StartedDay = "18",
                     StartedMonth = "8",
                     StartedYear = "2017",
                     SalaryPerHour = 100.50,
                     Seniority = 5.5,
                     IsActivated = true,
                     JobType = JopType.Director,
                     AddressId = 1,
                     BankAccountAccountNumber = 777777,
                     UserId = 7,
                 });
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
