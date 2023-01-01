using Microsoft.EntityFrameworkCore;
using Minimal_Web_API.Models;

namespace Minimal_Web_API.DataContext
{
    public class PTTContext : DbContext
    {
        public PTTContext(DbContextOptions<PTTContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<UserStop> UserStops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PTTDB;Trusted_Connection=True;Encrypt=False");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserStop>()
                .HasKey(us => new { us.UserLogin, us.StopId });
            modelBuilder.Entity<UserStop>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserStops)
                .HasForeignKey(us => us.UserLogin);
            modelBuilder.Entity<UserStop>()
                .HasOne(us => us.Stop)
                .WithMany(s => s.UserStops)
                .HasForeignKey(us => us.StopId);
        }
    }
}
