
using Microsoft.EntityFrameworkCore;
using TasksApi.Exceptions;
using TasksApi.Models;

namespace TasksApi.DAL
{
    public abstract class BaseCrudRepository<T, V> : ICrudRepository<T>
        where T : BaseEntity
        where V : DbContext
    {
        private readonly DbContext _context;

        public BaseCrudRepository(V context)
        {
            _context = context;
        }

        public async Task<T> Create(T entry)
        {
            _context.Add(entry);
            await _context.SaveChangesAsync();
            return entry;
        }

        public async Task<T> Update(T entry)
        {
            _context.Entry(entry).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entry;
        }

        public async Task Delete(T entry)
        {
            _context.Remove(entry);
            await _context.SaveChangesAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _context.FindAsync(typeof(T), id) as T;
        }

        public V GetContext()
        {
            return _context as V;
        }

        public abstract Task<IEnumerable<T>> GetAll();
        public abstract Task<bool> Exists(int id);
    }
}
