using Manufacturing_Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Interfaces
{
    public interface IStockService
    {
        Task<List<SelectListItem>> GetMaterials();
        Task<List<SelectListItem>> GetWarehouses();
        Task<List<SelectListItem>> GetLocations();

        Task<int> UpdateInventoryAsync(TrInventoryViewModel dto);
    }
}
