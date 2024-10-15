using Microsoft.EntityFrameworkCore;
using TasksApi.Models;

namespace TasksApi.DAL
{
    public class TodoTaskRepository : BaseCrudRepository<TodoTask>
    {
        public TodoTaskRepository(TodoTaskContext context) : base(context) { }


        public override async Task<bool> Exists(int id)
        {
            return await GetContext<TodoTaskContext>().TodoTasks.AnyAsync(t => t.Id == id);
        }

        public override async Task<IEnumerable<TodoTask>> GetAll()
        {
            return await GetContext<TodoTaskContext>().TodoTasks.ToListAsync();
        }
    }
}
