using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventodo.Domain
{
    public abstract class Module
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public Event Event { get; set; } = default!;
        [Required]
        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }
        public string ModuleType => this.GetType().Name;
    }
}
