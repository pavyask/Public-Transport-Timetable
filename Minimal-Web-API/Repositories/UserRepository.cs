using Microsoft.EntityFrameworkCore;
using Minimal_Web_API.DataContext;
using Minimal_Web_API.Models;

namespace Minimal_Web_API.Repositories;

public class UserRepository
{
    private readonly PTTContext _context;

    public UserRepository(PTTContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _context.Users
            .Include(user => user.UserStops)
            .ToListAsync();
    }

    public async Task<User?> GetUserByLoginAndPassword(string login, string password)
    {
        return await _context.Users
            .Include(user => user.UserStops)
            .FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
    }

    public async Task<IEnumerable<Stop>> GetUserStopsAsync(string login)
    {
        return await _context.Stops
            .Where(s => s.UserStops.Any(us => us.UserLogin == login))
            .ToListAsync();
    }

    public void SaveStopForUser(string login, string stopId)
    {
        var user = _context.Users.Include(u=>u.UserStops).FirstOrDefault(u => u.Login == login);
        var stop = _context.Stops.FirstOrDefault(s => s.StopId == stopId);

        if (user == null || stop == null) return;
        if (user.UserStops.Any(us => us.StopId == stopId)) return;

        var userStop = new UserStop
        {
            UserLogin = login,
            StopId = stopId,
        };
        _context.UserStops.Add(userStop);
        _context.SaveChanges();
    }

    public async Task<IEnumerable<Stop>> GetStopsExceptSavedByUser(string login)
    {
        return await _context.Stops
            .Where(s => s.UserStops.All(us => us.UserLogin != login))
            .ToListAsync();
    }
}
