using System.ComponentModel.DataAnnotations;

namespace Eventodo.Configurations.Options
{
    public class CorsOptions
    {
        public static readonly string SectionName = "Cors";
        [Required]
        [MinLength(1)]
        public string[] Origins { get; set; } = Array.Empty<string>();
    }
}
