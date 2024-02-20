using System.ComponentModel.DataAnnotations;

namespace Eventodo.Configurations.Options
{
    public class JWTOptions
    {
        public static readonly string SectionName = "Authentication:Jwt";
        [Required]
        [MaxLength(64)]
        public string Issuer { get; set; } = default!;
        [Required]
        [MaxLength(64)]
        public string Audience { get; set; } = default!;
        [Required]
        [MinLength(32)]
        [MaxLength(256)]
        public string SigningKey { get; set; } = default!;
        [Required]
        [Range(0, 1209600)]
        public int Expires { get; set; } = default!;
    }
}
