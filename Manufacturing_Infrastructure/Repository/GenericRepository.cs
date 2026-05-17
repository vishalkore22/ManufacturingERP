using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Manufacturing_Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDBContext dbContext, DbSet<T> dbSet)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<int> Delete(T entity)
        {
            var result = _dbSet.Remove(entity);
            return Convert.ToInt32(result);
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetEntity()
        {
            var entity = await _dbContext.TrStockGoodsORScrap.MaxAsync(x=>x.PkStGoodScrapId);
            if (entity != null)
            {
                entity = entity + 1;

                return entity;
            }
            return 0;
        }

        public async Task<List<T>> GetAllEnititiesAsync()
        {
            var entities = await _dbSet.ToListAsync();
            return entities;
        }

        public async Task<T> GetEntityByIdAsync(int id)
        {
            var entity= await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task<T> GetEntityByNameAsync(string name)
        {
            var entities = await _dbSet.FindAsync(name);
            return entities;
        }

        public async Task<int> SaveAsync(T entity)
        {
            var result =_dbSet.Add(entity);

            return Convert.ToInt32(result);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            var result= _dbSet.Update(entity);
            return Convert.ToInt32(result);
        }
    }
}
