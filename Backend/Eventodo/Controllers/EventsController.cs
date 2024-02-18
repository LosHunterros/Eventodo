using AutoMapper;
using Eventodo.Aplication.Repositorys;
using Eventodo.Aplication.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Eventodo.Core;
using Eventodo.Configurations.Options;
using System.Data;
using Microsoft.Extensions.Options;

namespace Eventodo.Controllers
{
    [ApiController]
    [Route("api/event/{url}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class EventsController : ControllerBase
    {
        private readonly IEventsRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly CacheOptions _cacheOptions;

        public EventsController(IEventsRepository repository, IMapper mapper, IMemoryCache memoryCache, IOptions<CacheOptions> cacheOptions)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            _cacheOptions = cacheOptions.Value ?? throw new ArgumentNullException(nameof(cacheOptions));
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "ResponseCache")]
        public async Task<ActionResult<EventDTO>> GetEvent(string url)
        {
            string cacheKey = $"{nameof(EventsController)}-{nameof(GetEvent)}-{url}";

            if (!_memoryCache.TryGetValue(cacheKey, out EventDTO? eventObjDTO))
            {
                Event? eventObj = await _repository.GetEventAsync(url);

                if (eventObj is not null)
                {
                    eventObjDTO = _mapper.Map<EventDTO>(eventObj);

                    _memoryCache.Set(cacheKey, eventObjDTO, TimeSpan.FromSeconds(_cacheOptions.MemoryCacheDuration));
                }
            }

            if (eventObjDTO is null)
            {
                return NotFound();
            }

            return Ok(eventObjDTO);
        }
    }
}
