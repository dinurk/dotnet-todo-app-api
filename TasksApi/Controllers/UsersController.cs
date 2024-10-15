using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TasksApi.DTO;
using TasksApi.Exceptions;
using TasksApi.Models;
using TasksApi.Services;

namespace TasksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICrudService<User> _service;
        private readonly IMapper _mapper;

        public UsersController(UserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _service.GetAll();
            return Ok(users.Select(user => _mapper.Map<UserDto>(user)));
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var todoTask = await _service.GetById(id);

            if (todoTask == null)
            {
                return NotFound();
            }

            return Ok(todoTask);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(CreateUserDto user)
        {
            var createdUser = await _service.Create(_mapper.Map<User>(user));

            return CreatedAtAction(
                actionName: nameof(PostUser),
                routeValues: new { id = createdUser.Id },
                value: _mapper.Map<UserDto>(createdUser)
            );
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                var updatedUser = await _service.Update(user);
                return Ok(_mapper.Map<UserDto>(updatedUser));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _service.Delete(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
