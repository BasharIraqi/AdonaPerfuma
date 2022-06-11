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
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime StartedDate { get; set; } = DateTime.Now.Date;

        [AllowNull]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } 

        [Required]
        public BankAccount bankAccount { get; set; }

        [Required]
        public double SalaryPerHour { get; set; }

        public double Seniority { get { return Seniority; } set {Seniority=(((DateTime.Now.Date-StartedDate.Date).TotalDays)/365); } }

        [Required]
        public bool IsActivated { get; set;}

        [Required]
        public JopType JobType { get; set; }

        [Required]
        public UserTypes User { get; set; }
    }

    public enum JopType
    {
        Director,
        Manager,
        General
    }
}
