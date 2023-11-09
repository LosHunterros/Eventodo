using Eventodo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Eventodo.Infrastructure
{
    public class EventodoDbContext : DbContext
    {
        public DbSet<Event> Events => Set<Event>();

        public EventodoDbContext(DbContextOptions<EventodoDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
