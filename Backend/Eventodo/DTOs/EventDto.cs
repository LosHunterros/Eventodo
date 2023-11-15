using Eventodo.Domain;

namespace Eventodo.DTOs
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public ICollection<Module> Modules { get; set; } = new List<Module>();
    }
}
