using TasksApi.Models;

namespace TasksApi.Services.Abstract
{
    public interface ICrudService<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity todoTask);
        Task<TEntity> UpdateAsync(TEntity todoTask);
        Task DeleteAsync(int todoTaskId);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
