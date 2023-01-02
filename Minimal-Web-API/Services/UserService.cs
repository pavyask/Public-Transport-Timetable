using AutoMapper;
using Minimal_Web_API.DTO;
using Minimal_Web_API.Models;
using Minimal_Web_API.Repositories;

namespace Minimal_Web_API.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetUserDTO>> GetUsersAsync()
        {
            var user = await _userRepository.GetUsersAsync();
            return _mapper.Map<IEnumerable<GetUserDTO>>(user);
        }

        public async Task<GetUserDTO> GetUserByLoginAndPassword(string login, string password)
        {
            var user = await _userRepository.GetUserByLoginAndPassword(login, password);
            return _mapper.Map<GetUserDTO>(user);
        }

        public async Task<IEnumerable<GetStopDTO>> GetUserStops(string login)
        {
            var stops = await _userRepository.GetUserStopsAsync(login);
            return _mapper.Map<IEnumerable<GetStopDTO>>(stops);
        }

        public async Task<IEnumerable<GetStopDTO>> GetStopsExceptSavedByUser(string login)
        {
            var stops = await _userRepository.GetStopsExceptSavedByUser(login);
            return _mapper.Map<IEnumerable<GetStopDTO>>(stops);
        }
        
        public void SaveStopsForUser(string login, ICollection<string> stopIds)
        {
            foreach (var stopId in stopIds)
            {
                _userRepository.SaveStopForUser(login, stopId);
            }
        }
    }
}
