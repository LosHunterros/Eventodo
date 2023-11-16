using Eventodo.Domain;
using Microsoft.Extensions.Logging;

namespace Eventodo.Infrastructure
{
    public interface IModulesRepository
    {
        Module? GetModule(int id);
        IEnumerable<Module> GetModules(int EventId);
        void CreateModule(Module Module);
        bool UpdateModule(Module Module);
        bool DeleteModule(int id);
        IEnumerable<string> GetModulesTypes();
    }
}
