using AutoMapper;
using Eventodo.Domain;
using Eventodo.DTOs;
using Eventodo.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Eventodo.Controllers
{
    [ApiController]
    [Route("api/modules")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ModulesController : ControllerBase
    {
        private readonly IModulesRepository _repository;
        private readonly IMapper _mapper;

        public ModulesController(IModulesRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("/types")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Event> GetModulesTypes()
        {
            return Ok(_repository.GetModulesTypes());
        }
    }
}
