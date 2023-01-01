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
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUserByLoginAndPassword(string login, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
    }
}
