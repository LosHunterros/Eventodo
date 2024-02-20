using System.ComponentModel.DataAnnotations;

namespace Eventodo.Aplication.DTOs
{
    public class UserDTO
    {
        [Required]
        [MaxLength(255)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
    }
}
