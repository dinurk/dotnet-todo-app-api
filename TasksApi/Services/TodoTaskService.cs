using TasksApi.DAL;
using TasksApi.Models;
using TasksApi.Services.Abstract;

namespace TasksApi.Services
{
    public class TodoTaskService : BaseCrudService<TodoTask>
    {
        public TodoTaskService(TodoTaskRepository repository)
            : base(repository) { }

        public async Task<IEnumerable<TodoTask>> GetByCreatorId(int creatorId)
        {
            return await GetRepository<TodoTaskRepository>()
                .GetByCreatorIdAsync(creatorId);
        }
    }
}
