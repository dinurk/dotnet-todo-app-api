namespace TasksApi.DAL.Abstract
{
    public interface ICrudRepository<TEntity>
    {
        Task<TEntity> CreateAsync(TEntity entry);
        Task<TEntity> UpdateAsync(TEntity entry);
        Task DeleteAsync(TEntity entry);
        Task<TEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<bool> ExistsAsync(int id);
    }
}
