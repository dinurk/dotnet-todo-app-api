namespace TasksApi.DTO.User
{
    public class UserDto
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email пользователя
        /// </summary>
        public string Email { get; set; }
    }
}
