using TasksApi.DAL;
using TasksApi.Models;
using TasksApi.Services.Abstract;

namespace TasksApi.Services
{
    public class UserService : BaseCrudService<User>
    {
        public UserService(UserRepository repository)
            : base(repository) { }
    }
}
