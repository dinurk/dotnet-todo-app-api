using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace TasksApi.Models
{
    public class TodoTaskContext : DbContext
    {
        public TodoTaskContext(DbContextOptions<TodoTaskContext> options)
            : base(options) { }

        public DbSet<TodoTask> TodoTasks { get; set; } = null!;
    }
}
