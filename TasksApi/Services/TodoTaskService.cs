using TasksApi.DAL;
using TasksApi.Models;

namespace TasksApi.Services
{
    public class TodoTaskService : BaseCrudService<TodoTask>
    {
        public TodoTaskService(TodoTaskRepository repository)
            : base(repository) { }
    }
}
