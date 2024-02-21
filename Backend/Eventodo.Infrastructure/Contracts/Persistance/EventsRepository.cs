using Eventodo.Core;
using Microsoft.EntityFrameworkCore;

namespace Eventodo.Infrastructure.Repositorys
{
    public class EventsRepository : IEventsRepository
    {
        private readonly EventodoDbContext _eventodoDbContext;

        public EventsRepository(EventodoDbContext eventodoDbContext)
        {
            _eventodoDbContext = eventodoDbContext ?? throw new ArgumentNullException(nameof(eventodoDbContext));
        }

        public async Task<Event?> GetEventAsync(string url)
        {
            return await _eventodoDbContext.Events.Include(c => c.Modules).FirstOrDefaultAsync(c => c.Url == url);
        }

        public Task<IEnumerable<Event>> GetEventsAsync(string? search)
        {
            throw new NotImplementedException();
        }

        public Task CreateEventAsync(Event eventObj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEventAsync(Event eventObj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEventAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
