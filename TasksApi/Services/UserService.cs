using TasksApi.DAL;
using TasksApi.Models;

namespace TasksApi.Services
{
    public class UserService : BaseCrudService<User>
    {
        public UserService(UserRepository repository)
            : base(repository) { }
    }
}
