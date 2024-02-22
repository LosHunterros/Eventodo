using System.ComponentModel.DataAnnotations;

namespace Eventodo.Aplication.DTOs
{
    public class UserRegisterDTO
    {
        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
