using Module = Eventodo.Core.Module;
using System.Reflection;

namespace Eventodo.Infrastructure.Repositorys
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
            return await _eventodoDbContext.Modules.FindAsync(id);
        }

        public Task<IEnumerable<Module>> GetModulesAsync(int eventId)
        {
            throw new NotImplementedException();
        }

        public Task CreateModuleAsync(Module module)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateModuleAsync(Module module)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteModuleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public string[] GetModulesTypes()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(Module)) ?? throw new NullReferenceException();
            string[] modulesTypes = assembly.GetTypes()
              .Where(e => String.Equals(e.Namespace, "Eventodo.Core.Modules", StringComparison.Ordinal))
              .Select(e => e.Name)
              .ToArray();

            return modulesTypes;
        }
    }
}
