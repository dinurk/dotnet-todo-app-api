using TasksApi.Models;

namespace TasksApi.Services
{
    public interface ICrudService<T> where T : BaseEntity
    {
        Task<T> Create(T todoTask);
        Task<T> Update(T todoTask);
        Task Delete(int todoTaskId);
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);
        Task<Boolean> Exists(int id);
    }
}
