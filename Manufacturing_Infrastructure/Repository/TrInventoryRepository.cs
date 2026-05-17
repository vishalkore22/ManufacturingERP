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
    public class TrInventoryRepository : ITrInventoryRepository
    {
        private readonly ApplicationDBContext _context;

        public TrInventoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<SelectListItem>> GetLocationAsync()
        {
            var location = await (from c in _context.MLocations
                                  select new SelectListItem
                                  {
                                      Text = c.LocationName,
                                      Value = c.LocationId.ToString()
                                  }).ToListAsync();
            return location;
        }

        public async Task<List<SelectListItem>> GetWarehouseAsync()
        {
            var warehouse = await (from c in _context.MWarehouses
                                   select new SelectListItem
                                   {
                                       Text = c.WarehouseName,
                                       Value = c.PkWarehouseId.ToString()
                                   }).ToListAsync();
            return warehouse;
        }

        public async Task<List<SelectListItem>> GetMaterialAsync()
        {
            var material = await (from c in _context.MMetarials
                                  select new SelectListItem
                                  {
                                      Text = c.MatName,
                                      Value = c.PkMatId.ToString()
                                  }).ToListAsync();
            return material;
        }

        // public async Task<int> CreateTrInventoryViewModelAsync(TrInventoryViewModel trInventoryViewModel)
        //{
        //try
        //{
        //    // 1. Validation
        //    if (trInventoryViewModel.Quantity <= 0)
        //        throw new Exception("Quantity must be greater than zero");

        //    // 2. Map DTO → Entity
        //    var inventory = new TrInventoryViewModel
        //    {
        //        Id = trInventoryViewModel.Id,
        //        MaterialId = trInventoryViewModel.MaterialId,
        //        WarehouseId = trInventoryViewModel.WarehouseId,
        //        LocationId = trInventoryViewModel.LocationId,
        //        TransactionType = trInventoryViewModel.TransactionType,
        //        Quantity = trInventoryViewModel.Quantity
        //    };
        //    var createinventory = await _inventory.AddAsync(inventory);
        //    // 3. Insert Inventory
        //    //await _inventoryRepo.AddAsync(inventory);

        //    // 4. Insert Stock Ledger (Single Source of Truth)
        //    var ledger = new TrStockLedger
        //    {
        //        StockLedgerId = trInventoryViewModel.Id,
        //        MaterialId = trInventoryViewModel.MaterialId,
        //        WarehouseId = trInventoryViewModel.WarehouseId,
        //        LocationId = trInventoryViewModel.LocationId,
        //        TransactionType = (int)trInventoryViewModel.TransactionType,
        //        Qty = (decimal)trInventoryViewModel.Quantity,
        //        TransactionDate = DateTime.Now,
        //        ReferenceId = trInventoryViewModel.Id
        //    };

        //    var stock = await _ledger.AddAsync(ledger);

        //    // 5. Update Current Stock
        //    await _stockService.UpdateStockAsync(dto);

        //    // 6. Save Changes
        //    await _unitOfWork.SaveChangesAsync();

        //    // 7. Commit Transaction
        //    await transaction.CommitAsync();

        //    return true;
        //}
        //catch (Exception ex)
        //{
        //    await transaction.RollbackAsync();
        //    throw;
        //}
        //}

        public async Task<List<TrInventoryViewModel>> GetTrInventoryViewModel()
        {
            var inventory = await (from c in _context.TrInventoryViewModels
                                   select new TrInventoryViewModel
                                   {
                                       Id = c.Id,
                                       MaterialId = c.MaterialId,
                                       WarehouseId = c.WarehouseId,
                                       LocationId = c.LocationId,
                                       TransactionType = c.TransactionType,
                                       Quantity = c.Quantity
                                   }).ToListAsync();
            return inventory;
        }
    }
}
