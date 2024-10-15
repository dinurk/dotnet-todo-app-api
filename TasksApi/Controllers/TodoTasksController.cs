using Microsoft.AspNetCore.Mvc;
using TasksApi.DAL;
using TasksApi.Exceptions;
using TasksApi.Models;
using TasksApi.Services;

namespace TasksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTasksController : ControllerBase
    {
        private readonly ICrudService<TodoTask> _service;

        public TodoTasksController(TodoTaskService service)
        {
            _service = service;
        }

        // GET: api/TodoTasks
        [HttpGet]
        public async Task<IActionResult> GetTodoTasks()
        {
            return Ok(await _service.GetAll());
        }

        // GET: api/TodoTasks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoTask(int id)
        {
            var todoTask = await _service.GetById(id);

            if (todoTask == null)
            {
                return NotFound();
            }

            return Ok(todoTask);
        }

        // POST: api/TodoTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoTask>> PostTodoTask(TodoTask todoTask)
        {
            await _service.Create(todoTask);

            return CreatedAtAction(nameof(GetTodoTask), new { id = todoTask.Id }, todoTask);
        }

        // PUT: api/TodoTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoTask(int id, TodoTask todoTask)
        {
            if (id != todoTask.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.Update(todoTask);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }

        // DELETE: api/TodoTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoTask(int id)
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
