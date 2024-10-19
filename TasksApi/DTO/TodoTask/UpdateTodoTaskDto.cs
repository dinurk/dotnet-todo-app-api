using TasksApi.Models;

namespace TasksApi.DTO.TodoTask
{
    public class UpdateTodoTaskDto : BaseEntity
    {

        /// <summary>
        /// Статус завершения задачи
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Наименование задачи
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Дедлайн
        /// </summary>
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Id пользователя, создавшего задачу
        /// </summary>
        public int CreatorId { get; set; }
    }
}
