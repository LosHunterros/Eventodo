using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Eventodo.Core
{
    [Index(nameof(Url), IsUnique = true)]
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Url { get; set; } = string.Empty;
        [Required]
        public string Title { get; set; } = string.Empty;
        public ICollection<Module> Modules { get; set; } = new List<Module>();
    }
}
