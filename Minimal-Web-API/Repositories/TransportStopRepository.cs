using Microsoft.EntityFrameworkCore;
using Minimal_Web_API.DataContext;

namespace Minimal_Web_API.Repositories
{
    public class TransportStopRepository
    {
        private readonly PTTContext _context;

        public TransportStopRepository(PTTContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TransportStop>> GetTransportStopsAsync()
        {
            return await _context.TransportStops.ToListAsync();
        }

        public async Task<IEnumerable<TransportStop>> GetTransportStopsOfUserAsync(string login)
        {
            return await _context.TransportStops
                .Include(t => t.Users)
                .Where(t => t.Users.Any(u => u.Login == login))
                .ToListAsync();
        }

        public void AddTransportStops(IEnumerable<TransportStop> transportStops)
        {
            foreach(var transportStop in transportStops)
            {
                var oldTransportStop = _context.TransportStops.FirstOrDefault(t => t.StopId == transportStop.StopId);
                if (oldTransportStop != null)
                {
                    //_context.TransportStops.Update(transportStop);
                    oldTransportStop.OverrideValues(transportStop);
                }
                else
                    _context.TransportStops.Add(transportStop);
                _context.SaveChanges();
            }
        }
    }
}
