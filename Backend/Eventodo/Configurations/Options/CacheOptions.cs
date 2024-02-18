using System.ComponentModel.DataAnnotations;

namespace Eventodo.Configurations.Options
{
    public class CacheOptions
    {
        public static readonly string SectionName = "Cache";
        [Required]
        [Range(0, 600)]
        public int ResponseCacheDuration { get; set; } = default!;
        [Required]
        [Range(0, 600)]
        public int MemoryCacheDuration { get; set; } = default!;
    }
}
