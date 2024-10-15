using TasksApi.Models;

namespace TasksApi.DAL
{
    public interface ICrudRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);
        Task<T> Create(T todoTask);
        Task<T> Update(T todoTask);
        Task Delete(int todoTaskId);
        Task<Boolean> Exists(int id);
    }
}
