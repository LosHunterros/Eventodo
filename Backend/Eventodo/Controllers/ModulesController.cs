using AutoMapper;
using Eventodo.Aplication.Repositorys;
using Eventodo.Aplication.DTOs;
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

        // GET api/modules/1
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ModuleDTO>> GetModule(int id)
        {
            var module = await _repository.GetModuleAsync(id);

            if (module is null)
            {
                return NotFound();
            }

            ModuleDTO moduleDTO = _mapper.Map<ModuleDTO>(module);

            return Ok(moduleDTO);
        }

        // GET api/modules/types
        [HttpGet("types")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<string>> GetModulesTypes()
        {
            return Ok(_repository.GetModulesTypes());
        }
    }
}
