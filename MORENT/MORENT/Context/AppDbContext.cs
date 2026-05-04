using Microsoft.EntityFrameworkCore;
using MORENT.Models;

namespace MORENT.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(c => c.PricePerDay)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Booking>()
                .Property(b => b.TotalPrice)
                .HasPrecision(18, 2);
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}
