using AutoMapper;
using TasksApi.Models;

namespace TasksApi.DTO.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
