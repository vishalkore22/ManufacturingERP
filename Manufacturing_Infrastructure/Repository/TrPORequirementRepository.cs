using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using ManufacturingERP_Application.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Infrastructure.Repository
{
    public class TrPORequirementRepository : ITrPORequirementRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public TrPORequirementRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TrPORequirementCollection>> GetRequirementCollectionAsync()
        {
            var Result = await (from c in _dbContext.TrPORequirementCollections
                                select new TrPORequirementCollection
                                {
                                    PkRequirementID = c.PkRequirementID,
                                    RequirementNumber = c.RequirementNumber,
                                    WorkOrderNumber = c.WorkOrderNumber,
                                    BOMNumber = c.BOMNumber,
                                    MatName=c.MatName
                                }).ToListAsync();

            return Result;
        }

        public async Task<int> GetRequirementIdAsync()
        {
            var reqId = await _dbContext.TrPORequirementCollections.MaxAsync(x => (int?)x.PkRequirementID) == null ? 0 : await _dbContext.TrPORequirementCollections.MaxAsync(x => (int?)x.PkRequirementID);
            if (reqId == null || reqId == 0)
            {
                return 1;
            }
            else
            {
                return (int)reqId+1;
            }
        }

        public async Task<string> GetWorkOrderNumber()
        {
            var reqId = await _dbContext.TrPORequirementCollections.MaxAsync(x => (int?)x.PkRequirementID) == null ? 0 : await _dbContext.TrPORequirementCollections.MaxAsync(x => (int?)x.PkRequirementID);
            if (reqId == null || reqId == 0)
            {
                reqId=1;
            }
            else
            {
                reqId= reqId+1;
            }

            string WoNum= DateTime.Now.ToString("ddMMyyyy")+"-"+reqId;
            return WoNum;

        }

        public async Task<List<SelectListItem>> BindMaterialDropDown()
        {
            var materialDropdown = await _dbContext.MMetarials
                                     .Select(c => new SelectListItem
                                     {
                                         Value = c.PkMatId.ToString(),
                                         Text = $"{c.PkMatId} - {c.MatCode} - {c.MatName}"
                                     }).ToListAsync();

            return materialDropdown;
        }

        public async Task<MMetarial> GetMatIdCodeNameAsync(int MaterialID)
        {
            var material= await (from c in _dbContext.MMetarials
                                 where c.PkMatId==MaterialID
                                 select new MMetarial
                                 {
                                     PkMatId =c.PkMatId,
                                     MatCode=c.MatCode,
                                     MatName=c.MatName,
                                     MatQty=c.MatQty
                                 }).FirstOrDefaultAsync();

            return material;
        }

        public async Task<string> GetBOMNumber()
        {
            var reqId = await _dbContext.TrPORequirementCollections.MaxAsync(x => (int?)x.PkRequirementID) == null ? 0 : await _dbContext.TrPORequirementCollections.MaxAsync(x => (int?)x.PkRequirementID);
            if (reqId == null || reqId == 0)
            {
                reqId = 1;
            }
            else
            {
                reqId = reqId + 1;
            }

            string BOMNum = DateTime.Now.ToString("ddMM") + reqId;
            return BOMNum;
        }

        public async Task<int> SaveRequirementCollection(TrPORequirementCollection model)
        {
            _dbContext.TrPORequirementCollections.Add(model);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> UpdateTrRequirementCollectionAsync(TrPORequirementCollection model)
        {
            _dbContext.TrPORequirementCollections.Update(model);
            var update = await _dbContext.SaveChangesAsync(); return update;
        }

        public async Task<TrPORequirementCollection> GetTrPORequirementCollectionById(int id)
        {
            var trReqColl = await _dbContext.TrPORequirementCollections.Where(x=>x.PkRequirementID==id).FirstOrDefaultAsync();

            return trReqColl;
        }

        public async Task<int> DeleteTrPORequirementCollectionByIdAsync(int id)
        {
            var trReqColl = await _dbContext.TrPORequirementCollections.Where(x => x.PkRequirementID == id).FirstOrDefaultAsync();
            _dbContext.TrPORequirementCollections.Remove(trReqColl);
            var del= await _dbContext.SaveChangesAsync();
            return del;
        }

        public async Task<int> UpdateInventoryAsync(TrInventoryViewModel dto)
        {
            var inventory = await _dbContext.TrInventoryViewModels.Where(x => x.MaterialId == dto.MaterialId && x.WarehouseId == dto.WarehouseId && x.LocationId == dto.LocationId).FirstOrDefaultAsync();

            if (inventory != null)
            {
                inventory.Quantity = inventory.Quantity + dto.Quantity;
                _dbContext.TrInventoryViewModels.Update(inventory);
                var update = await _dbContext.SaveChangesAsync();
                return update;
            }
            else
            {
                TrInventoryViewModel newInventory = new TrInventoryViewModel
                {
                    MaterialId = dto.MaterialId,
                    WarehouseId = dto.WarehouseId,
                    LocationId = dto.LocationId,
                    Quantity = dto.Quantity
                };
                _dbContext.TrInventoryViewModels.Add(newInventory);
                var add = await _dbContext.SaveChangesAsync();
                return add;

            }
        }
    }
}
