using Eventodo.Aplication.DTOs;

namespace Eventodo.Aplication.Services
{
    public interface IEventsService
    {
        Task<EventDTO?> GetEventAsync(string url, int memoryCacheDuration);
        Task<IEnumerable<EventDTO>> GetEventsAsync(string? search, int memoryCacheDuration);
        Task CreateEventAsync(EventDTO eventObjDTO);
        Task<bool> UpdateEventAsync(EventDTO eventObjDTO);
        Task<bool> DeleteEventAsync(int id);
    }
}
