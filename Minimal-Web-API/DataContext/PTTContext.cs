using Microsoft.EntityFrameworkCore;
using Minimal_Web_API.Models;

namespace Minimal_Web_API.DataContext
{
    public class PTTContext : DbContext
    {
        public PTTContext(DbContextOptions<PTTContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TransportStop> TransportStops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PTTDB;Trusted_Connection=True;Encrypt=False");
        }
    }
}
