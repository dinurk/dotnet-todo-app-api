using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TasksApi.Controllers.Abstract;
using TasksApi.DTO.QueryParams;
using TasksApi.DTO.User;
using TasksApi.Models;
using TasksApi.Services;

namespace TasksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController
        : BaseCrudController<User, UserDto, CreateUserDto, User, NoQueryParams>
    {
        public UsersController(UserService service, IMapper mapper)
            : base(service, mapper) { }
    }
}
