using Microsoft.EntityFrameworkCore;
using Tracker.Models;

namespace Tracker.Repository
{
    public class TrackerContext : DbContext
    {
        public TrackerContext(DbContextOptions<TrackerContext> options) : base(options)
        { }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Board> Boards { get; set; }
    }
}
