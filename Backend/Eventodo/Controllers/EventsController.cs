using AutoMapper;
using Eventodo.Domain;
using Eventodo.DTOs;
using Eventodo.Infrastructure;
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
        private readonly IMapper _mapper;

        public EventsController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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

            var eventObjDto = _mapper.Map<EventDto>(eventObj);

            return Ok(eventObjDto);
        }
    }
}
