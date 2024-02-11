namespace Eventodo.Aplication.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public IEnumerable<ModuleDTO> Modules { get; set; } = new List<ModuleDTO>();
    }
}
