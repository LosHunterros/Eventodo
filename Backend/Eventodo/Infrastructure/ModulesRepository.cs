using System.Reflection;
using Module = Eventodo.Domain.Module;

namespace Eventodo.Infrastructure
{
    public class ModulesRepository : IModulesRepository
    {
        private readonly EventodoDbContext _eventodoDbContext;

        public ModulesRepository(EventodoDbContext eventodoDbContext)
        {
            _eventodoDbContext = eventodoDbContext ?? throw new ArgumentNullException(nameof(eventodoDbContext));
        }

        public async Task<Module?> GetModuleAsync(int id)
        {
            return  await _eventodoDbContext.Modules.FindAsync(id);
        }

        public Task<IEnumerable<Module>> GetModulesAsync(int EventId)
        {
            throw new NotImplementedException();
        }

        public Task CreateModuleAsync(Module Module)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateModuleAsync(Module Module)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteModuleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetModulesTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var modulesAssembly = assembly.GetTypes()
              .Where(e => String.Equals(e.Namespace, "Eventodo.Domain.Modules", StringComparison.Ordinal))
              .Select(e => e.Name)
              .ToArray();

            return modulesAssembly;
        }

    }
}
