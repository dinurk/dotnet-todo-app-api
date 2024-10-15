using Microsoft.EntityFrameworkCore;
using TasksApi.DAL;
using TasksApi.Exceptions;
using TasksApi.Models;

namespace TasksApi.Services
{
    public abstract class BaseCrudService<T> : ICrudService<T>
           where T : BaseEntity
    {
        private readonly ICrudRepository<T> _repository;

        public BaseCrudService(ICrudRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Create(T entry)
        {
            return await _repository.Create(entry);
        }

        public async Task<T> Update(T entry)
        {
            const int maxAttemptCount = 3;
            Exception? lastException = null;
            for (int attempted = 0; attempted < maxAttemptCount; attempted++)
            {
                if (!await _repository.Exists(entry.Id))
                {
                    throw new NotFoundException();
                }

                try
                {
                    return await _repository.Update(entry);
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
            var entry = await _repository.GetById(id);
            if (entry == null)
            {
                throw new NotFoundException();
            }

            await _repository.Delete(entry);
        }

        public async Task<T?> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public Task<IEnumerable<T>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<bool> Exists(int id)
        {
            return _repository.Exists(id);
        }
    }
}
