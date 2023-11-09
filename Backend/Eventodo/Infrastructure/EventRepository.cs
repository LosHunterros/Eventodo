using Eventodo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Eventodo.Infrastructure
{
    public class EventRepository : IEventRepository
    {
        private readonly EventodoDbContext _eventodoDbContext;

        public EventRepository(EventodoDbContext eventodoDbContext)
        {
            _eventodoDbContext = eventodoDbContext ?? throw new ArgumentNullException(nameof(eventodoDbContext));
        }

        public Event? GetEvent(string url)
        {
            return _eventodoDbContext.Events.SingleOrDefault(c => c.Url == url);
        }

        public IEnumerable<Event> GetEvents(string? search)
        {
            throw new NotImplementedException();
        }

        public void CreateEvent(Event eventObj)
        {
            throw new NotImplementedException();
        }

        public bool UpdateContact(Event EventObj)
        {
            throw new NotImplementedException();
        }

        public bool DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

    }
}
