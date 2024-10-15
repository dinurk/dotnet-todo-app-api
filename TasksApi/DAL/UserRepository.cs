using Microsoft.EntityFrameworkCore;
using TasksApi.Models;

namespace TasksApi.DAL
{
    public class UserRepository : BaseCrudRepository<User, AppDbContext>
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async override Task<bool> Exists(int id)
        {
            return await GetContext().Users.AnyAsync(t => t.Id == id);
        }

        public async override Task<IEnumerable<User>> GetAll()
        {
            return await GetContext().Users.ToListAsync();
        }
    }
}
