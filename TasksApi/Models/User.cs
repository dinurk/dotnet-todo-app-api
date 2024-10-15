namespace TasksApi.Models
{
    public class User : BaseEntity
    {
        /** Имя пользователя */
        public string Name { get; set; }

        /** Email пользователя */
        public string Email { get; set; }

        /** Пароль пользователя */
        public string Password { get; set; }
    }
}
