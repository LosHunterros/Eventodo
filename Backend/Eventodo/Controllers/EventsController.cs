using Eventodo.Domain;
using Eventodo.Infrasctucture;
using Microsoft.AspNetCore.Mvc;

namespace Eventodo.Controllers
{
    [ApiController]
    [Route("api/event/{url:string}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventsController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Event> GetEvent(string url)
        {
            var eventObj = _eventRepository.GetEvent(url);

            if (eventObj is null)
            {
                return NotFound();
            }

            return Ok(eventObj);
        }
    }
}
