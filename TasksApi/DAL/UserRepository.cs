using Microsoft.EntityFrameworkCore;
using TasksApi.DAL.Abstract;
using TasksApi.Models;

namespace TasksApi.DAL
{
    public class UserRepository : BaseCrudRepository<User>
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async override Task<bool> ExistsAsync(int id)
        {
            return await GetContext<AppDbContext>()
                .Users
                .AnyAsync(user => user.Id == id);
        }

        public async override Task<IEnumerable<User>> GetAllAsync()
        {
            return await GetContext<AppDbContext>()
                .Users
                .ToListAsync();
        }
    }
}
