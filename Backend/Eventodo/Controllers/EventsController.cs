using AutoMapper;
using Eventodo.Domain;
using Eventodo.DTOs;
using Eventodo.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

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

        public EventsController(IEventsRepository repository, IMapper mapper, IMemoryCache memoryCache)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Any-20")]
        public ActionResult<EventDto> GetEvent(string url)
        {
            var cacheKey = $"{nameof(EventsController)}-{nameof(GetEvent)}-{url}";

            if (!_memoryCache.TryGetValue<EventDto>(cacheKey, out var eventObjDto))
            {
                var eventObj = _repository.GetEvent(url);

                if (eventObj is not null)
                {
                    eventObjDto = _mapper.Map<EventDto>(eventObj);

                    _memoryCache.Set(cacheKey, eventObjDto, TimeSpan.FromSeconds(20));
                }
            }

            if (eventObjDto is null)
            {
                return NotFound();
            }

            return Ok(eventObjDto);
        }
    }
}
