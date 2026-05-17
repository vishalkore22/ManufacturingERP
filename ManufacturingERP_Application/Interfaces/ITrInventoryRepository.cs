using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Interfaces
{
    public interface ITrInventoryRepository
    {
        Task<List<SelectListItem>> GetLocationAsync();

        Task<List<SelectListItem>> GetWarehouseAsync();

        Task<List<SelectListItem>> GetMaterialAsync();

        Task<List<TrInventoryViewModel>> GetTrInventoryViewModel();

        //Task<int> CreateTrInventoryViewModelAsync(TrInventoryViewModel trInventoryViewModel);
    }
}
