using Microsoft.EntityFrameworkCore;

namespace KolokowiumAPBD.Model
{
    public class KolokwiumDbContext : DbContext
    {
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Organiser> Organiser { get; set; }
        public DbSet<Artist_Event> Artist_Event { get; set; }
        public DbSet<Event_Organiser> Event_Organiser { get; set; }
        public KolokwiumDbContext(DbContextOptions options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Event_Organiser>().HasKey((e => new {e.IdEvent, e.IdOrganiser}));
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Artist_Event>().HasKey((e => new {e.IdArtist, e.IdEvent}));
        }
    }
}