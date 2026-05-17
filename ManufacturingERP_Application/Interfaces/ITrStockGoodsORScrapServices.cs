using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Interfaces
{
    public interface ITrStockGoodsORScrapServices
    {
        Task<List<StockViewModel>> GetStockGoodsORScrapsAsync();

        Task<int> SaveAsync(TrStockGoodsORScrap trStockGoodsORScrap);

        Task<TrStockGoodsORScrap> GetEntityByIdAsync(int id);

        Task<int> DeleteAsync(int id);

        Task<int> GetEntity();

        Task<int> UpdateAsync(TrStockGoodsORScrap trStockGoodsORScrap);
    }
}
