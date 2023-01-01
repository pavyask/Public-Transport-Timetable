using Microsoft.EntityFrameworkCore;
using Minimal_Web_API.DataContext;
using Minimal_Web_API.Models;

namespace Minimal_Web_API.Repositories
{
    public class StopRepository
    {
        private readonly PTTContext _context;

        public StopRepository(PTTContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stop>> GetStopsAsync()
        {
            return await _context.Stops.ToListAsync();
        }

        public void AddStops(IEnumerable<Stop> stops)
        {
            foreach (var stop in stops)
            {
                var oldStop = _context.Stops.FirstOrDefault(t => t.StopId == stop.StopId);
                if (oldStop != null)
                {
                    oldStop.OverrideValues(stop);
                }
                else
                    _context.Stops.Add(stop);
                
                _context.SaveChanges();
            }
        }
    }
}
