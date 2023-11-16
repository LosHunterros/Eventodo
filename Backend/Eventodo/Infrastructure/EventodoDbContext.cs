using Eventodo.Domain;
using Eventodo.Domain.Modules;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Metadata;

namespace Eventodo.Infrastructure
{
    public class EventodoDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModuleAgenda> ModulesAgenda { get; set; }

        public EventodoDbContext(DbContextOptions<EventodoDbContext> options) : base(options)
        {

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
