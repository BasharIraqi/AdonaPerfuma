using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AdonaPerfuma.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public double Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public DateTime StartedDate { get; set; }

        [AllowNull]
        public DateTime EndDate { get; set; } 

        [Required]
        public BankAccount BankAccount { get; set; }

        [Required]
        public double SalaryPerHour { get; set; }

        public double Seniority { get; set; }

        [Required]
        public bool IsActivated { get; set;}

        [Required]
        public JopType JobType { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Address Address { get; set; }
    }

    public enum JopType
    {
        Director,
        Manager,
        General
    }
}
