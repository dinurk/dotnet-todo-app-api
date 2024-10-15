using Microsoft.EntityFrameworkCore;
using TasksApi.Models;

namespace TasksApi.DAL
{
    public class TodoTaskRepository : BaseCrudRepository<TodoTask, AppDbContext>
    {
        public TodoTaskRepository(AppDbContext context) : base(context) { }

        public override async Task<bool> Exists(int id)
        {
            return await GetContext().TodoTasks.AnyAsync(t => t.Id == id);
        }

        public override async Task<IEnumerable<TodoTask>> GetAll()
        {
            return await GetContext().TodoTasks.ToListAsync();
        }
    }
}
