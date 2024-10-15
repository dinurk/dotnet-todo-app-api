namespace TasksApi.DTO
{
    public class CreateUserDto
    {
        /** Имя пользователя */
        public string Name { get; set; }

        /** Email пользователя */
        public string Email { get; set; }

        /** Пароль пользователя */
        public string Password { get; set; }
    }
}
