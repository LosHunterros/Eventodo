using Eventodo.Aplication.DTOs;

namespace Eventodo.Aplication.Services
{
    public interface IEventsService
    {
        Task<EventDTO?> GetEventAsync(string url, int memoryCacheDuration);
        Task<IEnumerable<EventDTO>> GetEventsAsync(string? search);
        Task CreateEventAsync(EventDTO eventObj);
        Task<bool> UpdateEventAsync(EventDTO eventObj);
        Task<bool> DeleteEventAsync(int id);
    }
}
