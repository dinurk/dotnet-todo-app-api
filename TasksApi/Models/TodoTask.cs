﻿using System.ComponentModel.DataAnnotations;

namespace TasksApi.Models
{
    public class TodoTask : BaseEntity
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
        /// Статус завершенности задачи
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Id пользователя, создавшего задачу
        /// </summary>
        public int CreatorId { get; set; }
        public User Creator { get; set; }
    }
}
