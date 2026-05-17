using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Infrastructure.Repository
{
    public class TrInventoryTransectionRepository: ITrInventoryTransectionRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public TrInventoryTransectionRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TrInventoryTransaction>> GetInventoryAsync()
        {
            var inventory = await (from t in _dbContext.TrInventoryTransaction
                                  join m in _dbContext.MMetarials
                                  on t.FkMatId equals m.PkMatId

                                  select new TrInventoryTransaction
                                  {
                                      PkInTransId=t.PkInTransId,
                                      MatName = m.MatName,
                                      TransType = t.TransType,
                                      Warehouse = t.FkWarehouseId== 1 ? "P-1" : "P-2",
                                      Qty = t.Qty,
                                      TransDate = t.TransDate,
                                      Location=t.LocationId==1? "Pune": "Mumbai"
                                      
                                  }).ToListAsync();

            return inventory;
        }

        public async Task<int> GetPkInventoryIdAsync()
        {
            var PkInvId = await _dbContext.TrInventoryTransaction.MaxAsync(x => (int?)x.PkInTransId) == null ? 1 : await _dbContext.TrInventoryTransaction.MaxAsync(x => (int?)x.PkInTransId);
            if (PkInvId != null && PkInvId > 0)
            {
                PkInvId = PkInvId + 1;
            }
            return (int)PkInvId;
        }

        public async Task<List<SelectListItem>> BindMaterialDropDownAsync()
        {
            var material = await _dbContext.MMetarials
                                 .Select(c => new SelectListItem
                                 {
                                     Value = Convert.ToString(c.PkMatId),
                                     Text = c.MatName
                                 }).ToListAsync();

            if (material != null)
            {
                return material;
            }
            return null;
        }

        public async Task<decimal> GetMaterialQtyAsync(int fkMatId)
        {
            //var qty = await (from c in _dbContext.MMetarials
            //                 where c.PkMatId == fkMatId
            //                 select new
            //                 {
            //                    c.MatQty
            //                 }).FirstOrDefaultAsync();

            var qty1 = await _dbContext.TrInventoryTransaction.Where(x => x.FkMatId == fkMatId).Select(x => x.Qty).FirstOrDefaultAsync();

            return (decimal)qty1;
        }

        public async Task<int> GetMaterialQtyByFkMatIdAsync(int FkMatId)
        {
            var qty = await _dbContext.MMetarials.Where(x => x.PkMatId == FkMatId).Select(x => x.MatQty).FirstOrDefaultAsync();

            return (int)qty;
        }


        public async Task<int> SaveInventoryTransAsync(TrInventoryTransaction model)
        {
            _dbContext.TrInventoryTransaction.Add(model);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<TrInventoryTransaction> GetTrInventoryTransactionByIdAsync(int id)
        {
            var invres =  _dbContext.TrInventoryTransaction.FirstOrDefault(x=>x.PkInTransId == id);

            return invres;
        }

        public async Task<int> UpdateTrInvTransactionAsync(TrInventoryTransaction model)
        {
           _dbContext.TrInventoryTransaction.Update(model);

            var result=  await _dbContext.SaveChangesAsync();

            return result;

        }

        public async Task<string> GetMaterialNameByMatIdAsync(int FkMatId)
        {
            var matName =await _dbContext.MMetarials.Where(x => x.PkMatId == FkMatId).Select(a=>a.MatName).FirstAsync();
            return matName;
        }

        public async Task<int> DeleteInventoryTransectionAsync(int id)
        {
            var invtransection = await _dbContext.TrInventoryTransaction.Where(a => a.PkInTransId == id).FirstOrDefaultAsync();
            
            if (invtransection.FkMatId <= 0)
                return 0;

            _dbContext.TrInventoryTransaction.Remove(invtransection);
            if (await _dbContext.SaveChangesAsync() <= 0)
                return 0;            

            return 1;
        }

        public async Task<int> UpdateMaterialStockAsync(TrInventoryTransaction model1)
        {
            _dbContext.TrInventoryTransaction.Update(model1);
            var stockUpSucc = await _dbContext.SaveChangesAsync(); return stockUpSucc;
        }

        public async Task<TrInventoryTransaction> GetMaterialInformationByMatIdAsync(int FkMatId)
        {
            var MaterialInfo=await _dbContext.TrInventoryTransaction.Where(x=>x.FkMatId==FkMatId).FirstOrDefaultAsync();
            return MaterialInfo;
        }

    }
}
 