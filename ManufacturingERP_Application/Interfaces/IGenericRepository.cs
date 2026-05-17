using Manufacturing_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> GetAllEnititiesAsync();

        Task<T> GetEntityByIdAsync(int id);

        Task<T> GetEntityByNameAsync(string name);

        Task<int> SaveAsync(T entity);

        Task<int> UpdateAsync(T entity);

        Task<int> DeleteAsync(int id);

        Task<int> GetEntity();
    }
}
