using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManufacturingERP_Application.Interfaces
{
    public interface ITrInventoryServices
    {
        //Task<List<SelectListItem>> GetLocationAsync();

        //Task<List<SelectListItem>> GetWarehouseAsync();

        //Task<List<SelectListItem>> GetMaterialAsync();

        Task<List<TrInventoryViewModel>> GetTrInventoryViewModel();

        Task<int> CreateTrInventoryViewModelAsync(TrInventoryViewModel trInventoryViewModel);
    }
}
