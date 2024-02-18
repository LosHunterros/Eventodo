using Eventodo.Aplication.DTOs;
using Microsoft.AspNetCore.Mvc;
using Eventodo.Configurations.Options;
using Microsoft.Extensions.Options;
using Eventodo.Aplication.Services;

namespace Eventodo.Controllers
{
    [ApiController]
    [Route("api/modules")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ModulesController : ControllerBase
    {
        private readonly IModulesService _service;
        private readonly CacheOptions _cacheOptions;

        public ModulesController(IModulesService service, IOptions<CacheOptions> cacheOptions)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _cacheOptions = cacheOptions.Value ?? throw new ArgumentNullException(nameof(cacheOptions));
        }

        [HttpGet()]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ModuleDTO>> GetModule(int id)
        {
            ModuleDTO? moduleDTO = await _service.GetModuleAsync(id, _cacheOptions.MemoryCacheDuration);

            if (moduleDTO is null)
            {
                return NotFound();
            }

            return Ok(moduleDTO);
        }

        [HttpGet()]
        [Route("types")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string[]> GetModulesTypes()
        {
            string[]? modulesTypes = _service.GetModulesTypes(_cacheOptions.MemoryCacheDuration);

            if (modulesTypes is null)
            {
                return NotFound();
            }

            return Ok(modulesTypes);
        }
    }
}
