using AutoMapper;
using Minimal_Web_API.DTO;
using Minimal_Web_API.Models;

namespace Minimal_Web_API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Stop, GetStopDTO>();
            CreateMap<User, GetUserDTO>()
                .ForMember(u => u.UserStopIds, opt => opt.MapFrom(u => u.UserStops.Select(us => us.StopId)));
        }
    }
}
