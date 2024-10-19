namespace TasksApi.DTO.TodoTask
{
    public class CreateTodoTaskDto
    {
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
