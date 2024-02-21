using Eventodo.Core;

namespace Eventodo.Infrastructure.Repositorys
{
    public interface IModulesRepository
    {
        Task<Module?> GetModuleAsync(int id);
        Task<IEnumerable<Module>> GetModulesAsync(int eventId);
        Task CreateModuleAsync(Module module);
        Task<bool> UpdateModuleAsync(Module module);
        Task<bool> DeleteModuleAsync(int id);
        string[] GetModulesTypes();
    }
}
