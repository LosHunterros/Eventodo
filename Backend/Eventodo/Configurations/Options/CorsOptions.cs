using System.ComponentModel.DataAnnotations;

namespace Eventodo.Configurations.Options
{
    public class CorsOptions
    {
        [Required]
        [MinLength(1)]
        public string[] Origins { get; set; } = Array.Empty<string>();
    }
}
