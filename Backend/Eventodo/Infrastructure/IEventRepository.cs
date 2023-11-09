using Eventodo.Domain;
using Microsoft.Extensions.Logging;

namespace Eventodo.Infrastructure
{
    public interface IEventRepository
    {
        Event? GetEvent(string url);
        IEnumerable<Event> GetEvents(string? search);
        void CreateEvent(Event eventObj);
        bool UpdateContact(Event EventObj);
        bool DeleteContact(int id);
    }
}
