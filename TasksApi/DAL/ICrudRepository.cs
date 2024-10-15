using TasksApi.Models;

namespace TasksApi.DAL
{
    public interface ICrudRepository<T>
    {
        Task<T> Create(T entry);
        Task<T> Update(T entry);
        Task Delete(T entry);
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<Boolean> Exists(int id);
    }
}
