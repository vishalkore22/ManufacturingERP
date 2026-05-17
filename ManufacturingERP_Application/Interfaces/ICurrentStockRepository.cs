using Manufacturing_Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Interfaces
{
    public interface ICurrentStockRepository
    {
        Task<int> UpdateCurrentStock(TrInventoryViewModel trInventoryViewModel);
    }
}
