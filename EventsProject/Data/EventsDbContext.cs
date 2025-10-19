using EventsProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsProject.Data
{

    public class EventsDbContext : DbContext
    {
        public EventsDbContext(DbContextOptions<EventsDbContext>options) : base(options)
        {
            
        }

        public DbSet<Event> EventsTable { get; set; }
    }
}
