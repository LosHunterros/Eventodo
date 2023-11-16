using Eventodo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Eventodo.Infrastructure
{
    public class EventsRepository : IEventsRepository
    {
        private readonly EventodoDbContext _eventodoDbContext;

        public EventsRepository(EventodoDbContext eventodoDbContext)
        {
            _eventodoDbContext = eventodoDbContext ?? throw new ArgumentNullException(nameof(eventodoDbContext));
        }

        public Event? GetEvent(string url)
        {
            return _eventodoDbContext.Events.Include(c => c.Modules).FirstOrDefault(c => c.Url == url);
        }

        public IEnumerable<Event> GetEvents(string? search)
        {
            throw new NotImplementedException();
        }

        public void CreateEvent(Event eventObj)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEvent(Event eventObj)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEvent(int id)
        {
            throw new NotImplementedException();
        }

    }
}
