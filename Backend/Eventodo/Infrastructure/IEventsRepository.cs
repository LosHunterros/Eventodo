using Eventodo.Domain;
using Microsoft.Extensions.Logging;

namespace Eventodo.Infrastructure
{
    public interface IEventsRepository
    {
        Event? GetEvent(string url);
        IEnumerable<Event> GetEvents(string? search);
        void CreateEvent(Event eventObj);
        bool UpdateEvent(Event eventObj);
        bool DeleteEvent(int id);
    }
}
