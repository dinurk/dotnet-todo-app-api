
using Microsoft.EntityFrameworkCore;
using TasksApi.Exceptions;
using TasksApi.Models;

namespace TasksApi.DAL
{
    public abstract class BaseCrudRepository<T> : ICrudRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;

        public BaseCrudRepository(DbContext context)
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
            const int maxAttemptCount = 3;
            Exception? lastException = null;
            for (int attempted = 0; attempted < maxAttemptCount; attempted++)
            {
                if (!await Exists(entry.Id))
                {
                    throw new NotFoundException();
                }

                try
                {
                    _context.Entry(entry).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    lastException = ex;
                }
            }

            if (lastException != null)
            {
                throw lastException;
            }
            return entry;
        }

        public async Task Delete(int id)
        {
            var entry = await _context.FindAsync(typeof(T), id);
            if (entry == null)
            {
                throw new NotFoundException();
            }

            _context.Remove(entry);
            await _context.SaveChangesAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _context.FindAsync(typeof(T), id) as T;
        }

        public V GetContext<V>() where V : DbContext
        {
            if (_context is not V)
            {
                throw new ArgumentException();
            }
            return _context as V;
        }

        public abstract Task<IEnumerable<T>> GetAll();

        public abstract Task<bool> Exists(int id);
    }
}
