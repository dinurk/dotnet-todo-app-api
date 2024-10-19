using Microsoft.EntityFrameworkCore;
using TasksApi.DAL.Abstract;
using TasksApi.Models;

namespace TasksApi.DAL
{
    public class TodoTaskRepository : BaseCrudRepository<TodoTask>
    {
        public TodoTaskRepository(AppDbContext context) : base(context) { }

        public override async Task<bool> ExistsAsync(int id)
        {
            return await GetContext<AppDbContext>()
                .TodoTasks
                .AnyAsync(todoTask => todoTask.Id == id);
        }

        public override async Task<IEnumerable<TodoTask>> GetAllAsync()
        {
            return await GetContext<AppDbContext>()
                .TodoTasks
                .ToListAsync();
        }

        public async Task<IEnumerable<TodoTask>> GetByCreatorIdAsync(int creatorId)
        {
            return await GetContext<AppDbContext>()
                .TodoTasks
                .Where(todoTask => todoTask.CreatorId == creatorId)
                .ToListAsync();
        }
    }
}
