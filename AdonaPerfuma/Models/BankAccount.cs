using System.ComponentModel.DataAnnotations;

namespace AdonaPerfuma.Models
{
    public class BankAccount
    {
        [Key]
        public int AccountNumber { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public BankCompany BankName { get; set; }

        [Required]
        public int BankNumber { get; set; }

    }

    public enum BankCompany
    {
        Leumi,
        Boalim,
        Discont,
        Masad,
        Mezrahi
    }
}