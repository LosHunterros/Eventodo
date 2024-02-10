using Eventodo.Domain;
using Eventodo.Domain.Modules;
using Microsoft.EntityFrameworkCore;
using Module = Eventodo.Domain.Module;

namespace Eventodo.Infrastructure
{
    public class EventodoDbContext : DbContext
    {
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Module> Modules => Set<Module>();
        public DbSet<ModuleAgenda> ModulesAgenda => Set<ModuleAgenda>();
        public DbSet<ModuleGalery> ModulesGalery => Set<ModuleGalery>();

        public EventodoDbContext(DbContextOptions<EventodoDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Module>().UseTpcMappingStrategy();

            modelBuilder.Entity<Event>().HasData
            (
                new Event
                {
                    Id = 1,
                    Url = "woodstock",
                    Title = "Woodstock"
                },
                new Event
                {
                    Id = 2,
                    Url = "open-er",
                    Title = "Open'er"
                }
            );

            modelBuilder.Entity<ModuleAgenda>().HasData
            (
                new ModuleAgenda
                {
                    Id = 1,
                    Title = "Agenda1",
                    EventId = 1,
                    Day = 1
                },
                new ModuleAgenda
                {
                    Id = 2,
                    Title = "Agenda2",
                    EventId = 2,
                    Day = 2
                }
            );

        }
    }
}
