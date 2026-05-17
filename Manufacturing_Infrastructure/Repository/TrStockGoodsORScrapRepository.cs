using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Infrastructure.Repository
{
    public class TrStockGoodsORScrapRepository : ITrStockGoodsORScrapRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public TrStockGoodsORScrapRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StockViewModel>> GetStockGoodsORScrapsAsync()
        {
            //var stock = await _dbContext.TrStockGoodsORScrap
            //            .Join(_dbContext.MWarehouses,
            //                c => c.FkWarehouseId,
            //                a => a.PkWarehouseId,
            //                (c, a) => new { c, a })
            //            .Join(_dbContext.MLocations,
            //                ca => ca.c.LocationId,
            //                l => l.LocationId,
            //                (ca, l) => new StockViewModel
            //                {
            //                    FkMatId = ca.c.FkMatId,
            //                    WarehouseName = ca.a.WarehouseName,
            //                    LocationName = l.LocationName,
            //                    Qty = ca.c.Qty,
            //                    CheckedDate = ca.c.CheckedDate,
            //                    UnitMeasurement = ca.c.UnitMeasurement,
            //                    FlagGoodsOrScrap = ca.c.FlagGoodsOrScrap
            //                })
            //            .ToListAsync();

            var stock = await (from c in _dbContext.TrStockGoodsORScrap
                                     join a in _dbContext.MWarehouses
                                         on c.FkWarehouseId equals a.PkWarehouseId
                                     join l in _dbContext.MLocations
                                         on c.LocationId equals l.LocationId
                                     join m in _dbContext.MMetarials 
                                        on c.FkMatId equals m.PkMatId
                                     select new StockViewModel
                                     {
                                         PkStGoodScrapId=c.PkStGoodScrapId,
                                         MaterialName = m.MatName,
                                         WarehouseName = a.WarehouseName,
                                         LocationName = l.LocationName,
                                         Qty = c.Qty,                                         
                                         FlagGoodsOrScrap = c.FlagGoodsOrScrap== 1 ? "Goods" : "Scraps"
                                     }).ToListAsync();

            return stock;
        }

        public async Task<int> SaveAsync(TrStockGoodsORScrap trStockGoodsORScrap)
        {
            _dbContext.TrStockGoodsORScrap.Add(trStockGoodsORScrap);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var stock=await _dbContext.TrStockGoodsORScrap.FirstOrDefaultAsync(x=>x.PkStGoodScrapId==id);

            _dbContext.TrStockGoodsORScrap.Remove(stock);

            return await _dbContext.SaveChangesAsync();
        }


        public async Task<TrStockGoodsORScrap> GetEntityByIdAsync(int id)
        {
            var entity = await _dbContext.TrStockGoodsORScrap.FindAsync(id);
            return entity;
        }

        public async Task<int> GetEntity()
        {
            var id = await _dbContext.TrStockGoodsORScrap.MaxAsync(x=>(int?)x.PkStGoodScrapId)== null ? 1 : await _dbContext.TrStockGoodsORScrap.MaxAsync(x => (int?)x.PkStGoodScrapId);

            if (id !=null)
            {
                id = id + 1;
                return (int)id;
            }

            return 0;
        }

        public async Task<int> UpdateAsync(TrStockGoodsORScrap trStockGoodsORScrap)
        {
            _dbContext.TrStockGoodsORScrap.Update(trStockGoodsORScrap);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
