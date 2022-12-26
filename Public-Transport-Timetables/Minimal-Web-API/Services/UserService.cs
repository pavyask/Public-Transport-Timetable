using Minimal_Web_API.Models;
using Minimal_Web_API.Repositories;

namespace Minimal_Web_API.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<User> GetUserByLoginAndPassword(string login, string password)
        {
            return await _userRepository.GetUserByLoginAndPassword(login, password);
        }
    }
}
