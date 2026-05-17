using Manufacturing_Core.Entity;

namespace ManufacturingERP.Areas.User.Controllers
{
    public interface IGenericService<T>
    {
        Task<int> GetEntity();
        Task<List<T>> GetAllEnititiesAsync();

        Task<T> GetEntityByIdAsync(int id);

        Task<T> GetEntityByNameAsync(string name);

        Task<int> SaveAsync(T entity);

        Task<int> UpdateAsync(T entity);

        Task<int> DeleteAsync(int id);
    }
}