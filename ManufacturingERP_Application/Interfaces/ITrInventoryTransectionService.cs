using Manufacturing_Core.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Interfaces
{
    public interface ITrInventoryTransectionService
    {
        Task<List<TrInventoryTransaction>> GetInventoryAsync();

        Task<int> GetPkInventoryIdAsync();

        Task<decimal> GetMaterialQtyAsync(int fkMatId);

        Task<int> SaveInventoryTransAsync(TrInventoryTransaction model);

        Task<TrInventoryTransaction> GetTrInventoryTransactionByIdAsync(int id);

        Task<int> UpdateTrInvTransactionAsync(TrInventoryTransaction model);

        Task<string> GetMaterialNameByMatIdAsync(int FkMatId);

        Task<int> GetMaterialQtyByFkMatIdAsync(int FkMatId);

        Task<int> DeleteInventoryTransectionAsync(int id);

        Task<int> UpdateMaterialStockAsync(TrInventoryTransaction model1);

        Task<TrInventoryTransaction> GetMaterialInformationByMatIdAsync(int FkMatId);
    }
}
