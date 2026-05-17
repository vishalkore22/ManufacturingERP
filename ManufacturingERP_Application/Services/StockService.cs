using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }       

        public async Task<List<SelectListItem>> GetMaterials()
        {
            var mmaterial= await _stockRepository.GetMaterials();
            return mmaterial;
        }

        public async Task<List<SelectListItem>> GetWarehouses()
        {
            var Warehouse= await _stockRepository.GetWarehouses();
            return Warehouse;
        }

        public async Task<List<SelectListItem>> GetLocations()
        {
            var location = await _stockRepository.GetLocations();
            return location;
        }

        public async Task<int> UpdateInventoryAsync(TrInventoryViewModel dto)
        {
            var result = await _stockRepository.UpdateInventoryAsync(dto);
            return result;
        }
    }
}
