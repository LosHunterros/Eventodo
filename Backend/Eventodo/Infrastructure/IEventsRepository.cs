using Eventodo.Domain;
using Microsoft.Extensions.Logging;

namespace Eventodo.Infrastructure
{
    public interface IEventsRepository
    {
        Task<Event?> GetEventAsync(string url);
        Task<IEnumerable<Event>> GetEventsAsync(string? search);
        Task CreateEventAsync(Event eventObj);
        Task<bool> UpdateEventAsync(Event eventObj);
        Task<bool> DeleteEventAsync(int id);
    }
}
