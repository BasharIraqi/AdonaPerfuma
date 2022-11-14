using System.ComponentModel.DataAnnotations;

namespace AdonaPerfuma.Models
{
    public class Employee
    {

        [Key]
        [MaxLength(9)]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        public double Age { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(2)]
        public string BirthDay { get; set; }

        [Required]
        [MaxLength(2)]
        public string BirthMonth { get; set; }

        [Required]
        [MaxLength(4)]
        public string BirthYear { get; set; }

        [Required]
        [MaxLength(2)]
        public string StartedDay { get; set; }

        [Required]
        [MaxLength(2)]
        public string StartedMonth { get; set; }

        [Required]
        [MaxLength(4)]
        public string StartedYear { get; set; }

        [Required]
        public BankAccount BankAccount { get; set; }

        public double SalaryPerHour { get; set; }

        public double Seniority { get; set; }

        [Required]
        public bool IsActivated { get; set; }

        public JopType JobType { get; set; }

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
