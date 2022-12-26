using Microsoft.EntityFrameworkCore;
using Minimal_Web_API.Models;

namespace Minimal_Web_API.DataContext
{
    public class PublicTransportTimetablesContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PublicTransportTimetablesDB;Trusted_Connection=True;Encrypt=False");
        }
    }
}
