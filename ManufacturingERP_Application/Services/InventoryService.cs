using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        public InventoryService(IInventoryRepository inventoryRepository)
        {
            this._inventoryRepository = inventoryRepository;
        }

        public async Task<List<TrInventoryViewModel>> GetInventoryViewModel()
        {
            var inventory = await _inventoryRepository.GetInventoryViewModel();
            return inventory;
        }

        public async Task<int> AddAsync(TrInventoryViewModel inventory)
        {
            var result = await _inventoryRepository.AddAsync(inventory);

            return result;
        }
    }
}
