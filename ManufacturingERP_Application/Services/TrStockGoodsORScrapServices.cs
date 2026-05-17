using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Services
{
    public class TrStockGoodsORScrapServices : ITrStockGoodsORScrapServices
    {
        private readonly ITrStockGoodsORScrapRepository _repository;

        public TrStockGoodsORScrapServices(ITrStockGoodsORScrapRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StockViewModel>> GetStockGoodsORScrapsAsync()
        {
            var stockgoods = await _repository.GetStockGoodsORScrapsAsync();
            return stockgoods;
        }

        public async Task<int> SaveAsync(TrStockGoodsORScrap trStockGoodsORScrap)
        {
            var GoodsORScrap = await _repository.SaveAsync(trStockGoodsORScrap);
            return GoodsORScrap;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var delete = await _repository.DeleteAsync(id);
            return delete;
        }

        public async Task<TrStockGoodsORScrap> GetEntityByIdAsync(int id)
        {
            var entity = await _repository.GetEntityByIdAsync(id);

            return entity;
        }

        public async Task<int> GetEntity()
        {
            var id = await _repository.GetEntity();

            return id;
        }

        public async Task<int> UpdateAsync(TrStockGoodsORScrap trStockGoodsORScrap)
        {
            var id = await _repository.UpdateAsync(trStockGoodsORScrap);
            return id;
        }
    }
}
