namespace TasksApi.DTO.TodoTask
{
    public class TodoTaskDto : CreateTodoTaskDto
    {
        /// <summary>
        /// Статус завершенности задачи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Статус завершенности задачи
        /// </summary>
        public bool IsComplete { get; set; }
    }
}
