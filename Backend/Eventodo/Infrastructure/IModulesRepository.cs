using Eventodo.Domain;
using Microsoft.Extensions.Logging;

namespace Eventodo.Infrastructure
{
    public interface IModulesRepository
    {
        Task<Module?> GetModuleAsync(int id);
        Task<IEnumerable<Module>> GetModulesAsync(int EventId);
        Task CreateModuleAsync(Module Module);
        Task<bool> UpdateModuleAsync(Module Module);
        Task<bool> DeleteModuleAsync(int id);
        IEnumerable<string> GetModulesTypes();
    }
}
