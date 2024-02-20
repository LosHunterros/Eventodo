using Eventodo.Aplication.DTOs;
using Eventodo.Aplication.Repositorys;
using Eventodo.Core;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;

namespace Eventodo.Aplication.Services
{
    public class ModulesService : IModulesService
    {
        private readonly IModulesRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public ModulesService(IModulesRepository repository, IMapper mapper, IMemoryCache memoryCache)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public async Task<ModuleDTO?> GetModuleAsync(int id, int memoryCacheDuration)
        {
            string cacheKey = $"{nameof(ModulesService)}-{nameof(GetModuleAsync)}-{id}";

            if (!_memoryCache.TryGetValue(cacheKey, out ModuleDTO? moduleDTO))
            {
                Module? module = await _repository.GetModuleAsync(id);

                if (module is not null)
                {
                    moduleDTO = _mapper.Map<ModuleDTO>(module);

                    _memoryCache.Set(cacheKey, moduleDTO, TimeSpan.FromSeconds(memoryCacheDuration));
                }
            }

            return moduleDTO;
        }

        public Task<IEnumerable<ModuleDTO>> GetModulesAsync(int eventId, int memoryCacheDuration)
        {
            throw new NotImplementedException();
        }

        public Task CreateModuleAsync(ModuleDTO moduleDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateModuleAsync(ModuleDTO moduleDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteModuleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public string[]? GetModulesTypes(int memoryCacheDuration)
        {
            string cacheKey = $"{nameof(ModulesService)}-{nameof(GetModulesTypes)}";

            if (!_memoryCache.TryGetValue(cacheKey, out string[]? modulesTypes))
            {
                modulesTypes = _repository.GetModulesTypes();

                if (modulesTypes is not null)
                {
                    _memoryCache.Set(cacheKey, modulesTypes, TimeSpan.FromSeconds(memoryCacheDuration));
                }
            }

            return modulesTypes;
        }
    }
}
