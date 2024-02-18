using Eventodo.Configurations.Options;
using Eventodo.Aplication.Services;
using Eventodo.Aplication.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Eventodo.Controllers
{
    [ApiController]
    [Route("api/event")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class EventsController : ControllerBase
    {
        private readonly IEventsService _service;
        private readonly CacheOptions _cacheOptions;

        public EventsController(IEventsService service, IOptions<CacheOptions> cacheOptions)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _cacheOptions = cacheOptions.Value ?? throw new ArgumentNullException(nameof(cacheOptions));
        }

        [HttpGet("{url}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "ResponseCache")]
        public async Task<ActionResult<EventDTO>> GetEvent(string url)
        {
            EventDTO? eventObjDTO = await _service.GetEventAsync(url, _cacheOptions.MemoryCacheDuration);

            if (eventObjDTO is null)
            {
                return NotFound();
            }

            return Ok(eventObjDTO);
        }
    }
}
