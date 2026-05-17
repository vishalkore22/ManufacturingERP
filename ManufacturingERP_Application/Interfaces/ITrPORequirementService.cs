using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Interfaces
{
    public interface ITrPORequirementService
    {
        Task<List<TrPORequirementCollection>> GetRequirementCollectionAsync();

        Task<int> GetRequirementIdAsync();

        Task<string> GetWorkOrderNumber();

        Task<string> GetBOMNumber();

        Task<List<SelectListItem>> BindMaterialDropDown();        

        Task<MMetarial> GetMatIdCodeNameAsync(int MaterialID);

        Task<int> SaveRequirementCollection(TrPORequirementCollection model);

        Task<int> UpdateTrRequirementCollectionAsync(TrPORequirementCollection model);

        Task<TrPORequirementCollection> GetTrPORequirementCollectionById(int id);

        Task<int> DeleteTrPORequirementCollectionByIdAsync(int id);

        Task<int> UpdateInventoryAsync(TrInventoryViewModel dto);
    }
}
