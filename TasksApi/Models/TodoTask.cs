using System.ComponentModel.DataAnnotations;

namespace TasksApi.Models
{
    public class TodoTask : BaseEntity
    {
        /** Наименование задачи */
        public string? Name { get; set; }

        /** Дедлайн */
        public DateTime Deadline { get; set; }

        /** Задача была выполнена */
        public bool IsComplete { get; set; }
    }
}
