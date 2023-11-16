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

        public Module? GetModule(int id)
        {
            return _eventodoDbContext.Modules.Find(id);
        }

        public IEnumerable<Module> GetModules(int EventId)
        {
            throw new NotImplementedException();
        }

        public void CreateModule(Module Module)
        {
            throw new NotImplementedException();
        }

        public bool UpdateModule(Module Module)
        {
            throw new NotImplementedException();
        }

        public bool DeleteModule(int id)
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
