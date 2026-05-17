using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Services
{
    public class TrInventoryTransectionService: ITrInventoryTransectionService
    {
        private readonly ITrInventoryTransectionRepository _repository;

        public TrInventoryTransectionService(ITrInventoryTransectionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TrInventoryTransaction>> GetInventoryAsync()
        {
            var inventory = await _repository.GetInventoryAsync(); 
            return inventory;
        }

        public async Task<int> GetPkInventoryIdAsync()
        {
            var PkTrInvId = await _repository.GetPkInventoryIdAsync();
            return PkTrInvId;
        }

        public async Task<List<SelectListItem>> BindMaterialDropDownAsync()
        {
            var material = await _repository.BindMaterialDropDownAsync();
            if (material == null)
            {
                return material;
            }
            return null;
        }

        public async Task<decimal> GetMaterialQtyAsync(int fkMatId)
        {
            var qty = await _repository.GetMaterialQtyAsync(fkMatId);
            return qty;
        }

        public async Task<int> GetMaterialQtyByFkMatIdAsync(int FkMatId)
        {
            var qty = await _repository.GetMaterialQtyByFkMatIdAsync(FkMatId);
            return qty;
        }

        public async Task<int> SaveInventoryTransAsync(TrInventoryTransaction model)
        {
            var result = await _repository.SaveInventoryTransAsync(model);
            return result;
        }

        public async Task<TrInventoryTransaction> GetTrInventoryTransactionByIdAsync(int id)
        {
            var inventory = await _repository.GetTrInventoryTransactionByIdAsync(id);
            return inventory;
        }

        public async Task<int> UpdateTrInvTransactionAsync(TrInventoryTransaction model)
        {
            var inv = await _repository.UpdateTrInvTransactionAsync(model);
            return inv;
        }

        public async Task<string> GetMaterialNameByMatIdAsync(int FkMatId)
        {
            var matName = await _repository.GetMaterialNameByMatIdAsync(FkMatId);
            return matName;
        }

        public async Task<int> DeleteInventoryTransectionAsync(int id)
        {
            var inventorydelete = await _repository.DeleteInventoryTransectionAsync(id);
            return inventorydelete;
        }

        public async Task<int> UpdateMaterialStockAsync(TrInventoryTransaction model1)
        {
            var invstock = await _repository.UpdateMaterialStockAsync(model1);
            return invstock;
        }

        public async Task<TrInventoryTransaction> GetMaterialInformationByMatIdAsync(int FkMatId)
        {
            var inventoryStock = await _repository.GetMaterialInformationByMatIdAsync(FkMatId); return inventoryStock;
        }
    }
}
