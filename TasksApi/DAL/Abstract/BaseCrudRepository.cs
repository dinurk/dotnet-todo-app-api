
using Microsoft.EntityFrameworkCore;
using TasksApi.Exceptions;
using TasksApi.Models;

namespace TasksApi.DAL.Abstract
{
    public abstract class BaseCrudRepository<TEntity> : ICrudRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly DbContext _context;

        public BaseCrudRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entry)
        {
            _context.Add(entry);
            await _context.SaveChangesAsync();
            return entry;
        }

        public async Task<TEntity> UpdateAsync(TEntity entry)
        {
            _context.Entry(entry).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entry;
        }

        public async Task DeleteAsync(TEntity entry)
        {
            _context.Remove(entry);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _context.FindAsync(typeof(TEntity), id) as TEntity;
        }

        public TContext GetContext<TContext>() where TContext : DbContext
        {
            return _context as TContext;
        }

        public abstract Task<IEnumerable<TEntity>> GetAllAsync();
        public abstract Task<bool> ExistsAsync(int id);
    }
}
