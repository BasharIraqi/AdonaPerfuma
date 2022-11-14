using System.ComponentModel.DataAnnotations;

namespace AdonaPerfuma.Models
{
    public class BankAccount
    {
        [Key]
        [MaxLength(6)]
        public int AccountNumber { get; set; }

        [Required]
        [MaxLength(9)]
        public int OwnerId { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        public BankCompany Name { get; set; }

        [Required]
        [MaxLength(3)]
        public int BranchNumber { get; set; }

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