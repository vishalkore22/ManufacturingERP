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
    public interface IPurchaseOrderService
    {
        Task<int> GetPurchaseOrderId();

        Task<string> GetPONumberById();

        Task<List<SelectListItem>> BindSupplierDropdown();

        Task<int> SavePurchaseOrderAsync(PurchaseOrderViewModel model);

        Task<int> SavePurchaseOrderDetailsAsync(PurchaseOrderViewModel Model);

        Task<MPurchaseOrder> GetPurchaseOrderByIdAsync(int id);

        Task<List<MPurchaseOrderDetails>> GetPurchaseOrderDetailsByIdAsync(int id);

        Task<int> RejectAndArchiveAsync(int id);        
    }
}
