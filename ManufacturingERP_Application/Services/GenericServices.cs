using Manufacturing_Core.Entity;
using ManufacturingERP.Areas.User.Controllers;
using ManufacturingERP_Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Services
{
    public class GenericServices<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _generic;

        public GenericServices(IGenericRepository<T> genericRepository)
        {
            _generic = genericRepository;
        }

        public async Task<int> GetEntity()
        {
            var Id =await _generic.GetEntity();

            return Id;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var delete=await _generic.DeleteAsync(id);
            return delete;
        }

        public async Task<List<T>> GetAllEnititiesAsync()
        {
            var list=await _generic.GetAllEnititiesAsync();
            return list;
        }

        public Task<T> GetEntityByIdAsync(int id)
        {
            var entity= _generic.GetEntityByIdAsync(id);
            return entity;
        }

        public async Task<T> GetEntityByNameAsync(string name)
        {
            var entity =await _generic.GetEntityByNameAsync(name);
            return entity;
        }

        public async Task<int> SaveAsync(T entity)
        {
            var result=await _generic.SaveAsync(entity);
            return result;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            var result=await _generic.UpdateAsync(entity);
            return result;
        }
    }
}
