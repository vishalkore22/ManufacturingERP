using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ManufacturingERP_Application.Services
{
    public class TrInventoryServices : ITrInventoryServices
    {
        private readonly ITrInventoryRepository _trInventoryRepository;
        private readonly IInventoryService _inventory;
        private readonly IStockLedgerRepository _ledger;
        private readonly ICurrentStockRepository _currentStock;
        private readonly IUnitOfWorkServices _unitOfWork;
        private readonly IStockService _stockService;
        public TrInventoryServices(ITrInventoryRepository trInventoryRepository,
                                    IInventoryService inventoryService,
                                    IStockLedgerRepository ledger,
                                    ICurrentStockRepository currentStock,
                                    IUnitOfWorkServices unitOfWork,
                                    IStockService stockService)
        {
            _trInventoryRepository = trInventoryRepository;
            _inventory = inventoryService;
            _ledger = ledger;
            _currentStock = currentStock;
            _unitOfWork = unitOfWork;
            _stockService = stockService;
        }

        public async Task<List<SelectListItem>> GetLocationAsync()
        {
            var location = await _trInventoryRepository.GetLocationAsync();
            return location;
        }

        public async Task<List<SelectListItem>> GetWarehouseAsync()
        {
            var warehouse = await _trInventoryRepository.GetWarehouseAsync();

            return warehouse;
        }

        public async Task<List<SelectListItem>> GetMaterialAsync()
        {
            var material = await _trInventoryRepository.GetMaterialAsync();

            return material;
        }

        public async Task<List<TrInventoryViewModel>> GetTrInventoryViewModel()
        {
            var inventory = await _trInventoryRepository.GetTrInventoryViewModel();
            return inventory;
        }

        public async Task<int> CreateTrInventoryViewModelAsync(TrInventoryViewModel trInventoryViewModel)
        {
            try
            {
               
                // 1. Validation
                if (trInventoryViewModel.Quantity <= 0)
                    throw new Exception("Quantity must be greater than zero");

                // 2. Map DTO → Entity
                var inventory = new TrInventoryViewModel
                {
                    Id = trInventoryViewModel.Id,
                    MaterialId = trInventoryViewModel.MaterialId,
                    WarehouseId = trInventoryViewModel.WarehouseId,
                    LocationId = trInventoryViewModel.LocationId,
                    TransactionType = trInventoryViewModel.TransactionType,
                    Quantity = trInventoryViewModel.Quantity
                };
                var createinventory = await _inventory.AddAsync(inventory);
                // 3. Insert Inventory
                //await _inventoryRepo.AddAsync(inventory);

                // 4. Insert Stock Ledger (Single Source of Truth)
                var ledger = new TrStockLedger
                {
                    StockLedgerId = trInventoryViewModel.Id,
                    MaterialId = trInventoryViewModel.MaterialId,
                    WarehouseId = trInventoryViewModel.WarehouseId,
                    LocationId = trInventoryViewModel.LocationId,
                    TransactionType = (int)trInventoryViewModel.TransactionType,
                    Qty = (decimal)trInventoryViewModel.Quantity,
                    TransactionDate = DateTime.Now,
                    ReferenceId = trInventoryViewModel.Id
                };

                var stock = await _ledger.AddAsync(ledger);

                // 5. Update Current Stock
                var stock1=await UpdateCurrentStock(trInventoryViewModel);               

                return stock1;
            }
            catch (Exception ex)
            {                
                throw;
            }
        }

        private async Task<int> UpdateCurrentStock(TrInventoryViewModel trInventoryViewModel)
        {
            var currentStock = await _currentStock.UpdateCurrentStock(trInventoryViewModel);

            if (currentStock != null)
            {
                return currentStock;
            }

            return 0;           
        }
    }
}
