using Manufacturing_Core.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Interfaces
{
    public interface ITrInventoryTransectionRepository
    {
        Task<List<TrInventoryTransaction>> GetInventoryAsync();

        Task<int> GetPkInventoryIdAsync();

        Task<List<SelectListItem>> BindMaterialDropDownAsync();

        Task<decimal> GetMaterialQtyAsync(int fkMatId);

        Task<int> GetMaterialQtyByFkMatIdAsync(int FkMatId);

        Task<int> SaveInventoryTransAsync(TrInventoryTransaction model);

        Task<TrInventoryTransaction> GetTrInventoryTransactionByIdAsync(int id);

        Task<int> UpdateTrInvTransactionAsync(TrInventoryTransaction model);

        Task<string> GetMaterialNameByMatIdAsync(int FkMatId);

        Task<int> DeleteInventoryTransectionAsync(int id);

        Task<int> UpdateMaterialStockAsync(TrInventoryTransaction model1);

        Task<TrInventoryTransaction> GetMaterialInformationByMatIdAsync(int FkMatId);
    }
}
