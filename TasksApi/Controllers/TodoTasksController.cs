using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TasksApi.Controllers.Abstract;
using TasksApi.DTO.QueryParams;
using TasksApi.DTO.TodoTask;
using TasksApi.Models;
using TasksApi.Services;

namespace TasksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTasksController
        : BaseCrudController<TodoTask, TodoTaskDto, CreateTodoTaskDto, UpdateTodoTaskDto, TodoTaskQueryParams>
    {

        private readonly UserService _userService;
        public TodoTasksController(
            UserService userService,
            TodoTaskService service,
            IMapper mapper
        ) : base(service, mapper)
        {
            _userService = userService;
        }

        // GET: api/TodoTasks?creatorId=<creatorId>
        [HttpGet]
        public override async Task<IActionResult> GetAll(
            [FromQuery] TodoTaskQueryParams queryParams
        )
        {
            if (queryParams.CreatorId == null)
            {
                return await base.GetAll(queryParams);
            }

            if (!await _userService.ExistsAsync((int)queryParams.CreatorId))
            {
                return NotFound($"Пользователь с id {queryParams.CreatorId} не был найден");
            }

            var todoTasks = await GetService<TodoTaskService>().GetByCreatorId((int)queryParams.CreatorId);

            return Ok(
                todoTasks.Select(
                    todoTask => _mapper.Map<TodoTaskDto>(todoTask)
                )
            );
        }
    }
}
