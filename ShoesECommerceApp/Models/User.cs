using System.ComponentModel.DataAnnotations;

namespace ShoesECommerceApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string? Name { get; set; }
        [Required]

        public string? Gender { get; set; }
        [Required]

        public int? Age { get; set; }
        [Required]

        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; } = null!;


    }
}
