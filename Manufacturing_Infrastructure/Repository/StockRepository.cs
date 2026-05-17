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
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<SelectListItem>> GetLocations()
        {
            var Location = await (from c in _context.MLocations
                                  select new SelectListItem
                                  {
                                      Text = c.LocationName.ToString(),
                                      Value = c.LocationId.ToString()
                                  }).ToListAsync();
            return Location;
        }

        public async Task<List<SelectListItem>> GetMaterials()
        {
            var materialList = await (from c in _context.MMetarials
                                      select new SelectListItem
                                      {
                                          Text = c.MatName,
                                          Value = c.PkMatId.ToString()
                                      }).ToListAsync();
            return materialList;
        }

        public async Task<List<SelectListItem>> GetWarehouses()
        {
            var warehouse = await (from c in _context.MWarehouses
                                   select new SelectListItem
                                   {
                                       Text = c.WarehouseName,
                                       Value = c.PkWarehouseId.ToString()
                                   }).ToListAsync();
            return warehouse;
        }

        public async Task<int> UpdateInventoryAsync(TrInventoryViewModel dto)
        {
            var inventory = await _context.TrInventories.FirstOrDefaultAsync(x => x.MaterialId == dto.MaterialId);
            if (inventory != null)
            {
                inventory.Quantity = Convert.ToDecimal(dto.Quantity);
                inventory.LocationId = dto.LocationId;
                inventory.WarehouseId = dto.WarehouseId;
                _context.TrInventories.Update(inventory);
            }
            else
            {
                var newInventory = new TrInventory
                {
                    MaterialId = dto.MaterialId,
                    Quantity = Convert.ToDecimal(dto.Quantity),
                    LocationId = dto.LocationId,
                    WarehouseId = dto.WarehouseId
                };
                await _context.TrInventories.AddAsync(newInventory);
            }
            return await _context.SaveChangesAsync();
        }
    }
}
