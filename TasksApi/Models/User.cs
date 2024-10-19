using Microsoft.Extensions.Hosting;

namespace TasksApi.Models
{
    public class User : BaseEntity
    {
        /// <summary>
        /// Имя пользователя 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email пользователя 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя 
        /// </summary>
        public string Password { get; set; }

        public ICollection<TodoTask> TodoTasks { get; }
    }
}
