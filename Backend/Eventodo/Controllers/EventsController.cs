using AutoMapper;
using Eventodo.Domain;
using Eventodo.DTOs;
using Eventodo.Infrastructure;
using Microsoft.AspNetCore.Mvc;

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

        public EventsController(IEventsRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EventDto> GetEvent(string url)
        {
            var eventObj = _repository.GetEvent(url);

            if (eventObj is null)
            {
                return NotFound();
            }

            var eventObjDto = _mapper.Map<EventDto>(eventObj);

            return Ok(eventObjDto);
        }
    }
}
