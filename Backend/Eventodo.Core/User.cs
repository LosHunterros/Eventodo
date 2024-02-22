using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Eventodo.Core
{
    public class User : IdentityUser
    {
        [Required]
        [MinLength(2)]
        public override string? UserName { get; set; } = string.Empty;
    }
}
