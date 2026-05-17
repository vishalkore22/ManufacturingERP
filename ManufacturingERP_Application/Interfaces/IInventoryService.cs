using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Interfaces
{
    public interface IInventoryService
    {
        Task<List<TrInventoryViewModel>> GetInventoryViewModel();

        Task<int> AddAsync(TrInventoryViewModel inventory);
    }
}
