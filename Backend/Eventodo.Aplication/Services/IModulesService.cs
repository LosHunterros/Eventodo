using Eventodo.Aplication.DTOs;

namespace Eventodo.Aplication.Services
{
    public interface IModulesService
    {
        Task<ModuleDTO?> GetModuleAsync(int id, int memoryCacheDuration);
        Task<IEnumerable<ModuleDTO>> GetModulesAsync(int eventId, int memoryCacheDuration);
        Task CreateModuleAsync(ModuleDTO module);
        Task<bool> UpdateModuleAsync(ModuleDTO moduleDTO);
        Task<bool> DeleteModuleAsync(int id);
        string[]? GetModulesTypes(int memoryCacheDuration);
    }
}
