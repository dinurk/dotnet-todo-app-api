using AutoMapper;
using TasksApi.DTO.User;

namespace TasksApi.DTO.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUserDto, Models.User>();
            CreateMap<Models.User, UserDto>();
        }
    }
}
