using Eventodo.Aplication.DTOs;
using Eventodo.Aplication.Repositorys;
using Eventodo.Core;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;

namespace Eventodo.Aplication.Services
{
    public class EventsService : IEventsService
    {
        private readonly IEventsRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public EventsService(IEventsRepository repository, IMapper mapper, IMemoryCache memoryCache)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public async Task<EventDTO?> GetEventAsync(string url, int memoryCacheDuration)
        {
            string cacheKey = $"{nameof(EventsService)}-{nameof(GetEventAsync)}-{url}";

            if (!_memoryCache.TryGetValue(cacheKey, out EventDTO? eventObjDTO))
            {
                Event? eventObj = await _repository.GetEventAsync(url);

                if (eventObj is not null)
                {
                    eventObjDTO = _mapper.Map<EventDTO>(eventObj);

                    _memoryCache.Set(cacheKey, eventObjDTO, TimeSpan.FromSeconds(memoryCacheDuration));
                }
            }

            return eventObjDTO;
        }

        public Task<IEnumerable<EventDTO>> GetEventsAsync(string? search, int memoryCacheDuration)
        {
            throw new NotImplementedException();
        }

        public Task CreateEventAsync(EventDTO eventObjDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEventAsync(EventDTO eventObjDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEventAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
