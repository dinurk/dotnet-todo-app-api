using TasksApi.DAL.Abstract;
using TasksApi.Exceptions;
using TasksApi.Models;

namespace TasksApi.Services.Abstract
{
    public abstract class BaseCrudService<TEntity> : ICrudService<TEntity>
           where TEntity : BaseEntity
    {
        private readonly ICrudRepository<TEntity> _repository;

        public BaseCrudService(ICrudRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TEntity> CreateAsync(TEntity entry)
        {
            return await _repository.CreateAsync(entry);
        }

        public async Task<TEntity> UpdateAsync(TEntity entry)
        {
            const int maxAttemptCount = 3;
            Exception? lastException = null;
            for (int attempted = 0; attempted < maxAttemptCount; attempted++)
            {
                if (!await _repository.ExistsAsync(entry.Id))
                {
                    throw new NotFoundException();
                }

                try
                {
                    return await _repository.UpdateAsync(entry);
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

        public async Task DeleteAsync(int id)
        {
            var entry = await _repository.GetByIdAsync(id);
            if (entry == null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteAsync(entry);
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<bool> ExistsAsync(int id)
        {
            return _repository.ExistsAsync(id);
        }

        public TRepository GetRepository<TRepository>()
            where TRepository : BaseCrudRepository<TEntity>
        {
            return _repository as TRepository;
        }
    }
}
