using System.ComponentModel.DataAnnotations;

namespace AdonaPerfuma.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Path { get; set; }
    }
}
