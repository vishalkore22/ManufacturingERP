using Manufacturing_Core.Entity;
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
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task<int> GetPurchaseOrderId()
        {
            var purchaseOrderId = await _purchaseOrderRepository.GetPurchaseOrderId();
            if (purchaseOrderId == null)
            {
                return 0;
            }
            return purchaseOrderId;
        }

        public async Task<string> GetPONumberById()
        {
            var poNumber = await _purchaseOrderRepository.GetPONumberById();
            if (poNumber == null)
            {
                return string.Empty;
            }
            return poNumber;
        }

        public async Task<List<SelectListItem>> BindSupplierDropdown()
        {
            var supplierList = await _purchaseOrderRepository.BindSupplierDropdown();
            if (supplierList == null)
            {
                return null;
            }
            return supplierList;
        }

        public async Task<int> SavePurchaseOrderAsync(PurchaseOrderViewModel model)
        {
            var savePO = await _purchaseOrderRepository.SavePurchaseOrderAsync(model);
            return savePO;
        }

        public async Task<int> SavePurchaseOrderDetailsAsync(PurchaseOrderViewModel Model)
        {
            var podetails = await _purchaseOrderRepository.SavePurchaseOrderDetailsAsync(Model);

            return podetails;
        }

        public async Task<MPurchaseOrder> GetPurchaseOrderByIdAsync(int id)
        {
            var porder = await _purchaseOrderRepository.GetPurchaseOrderByIdAsync(id);
            return porder;
        }

        public async Task<List<MPurchaseOrderDetails>> GetPurchaseOrderDetailsByIdAsync(int id)
        {
            var podetails = await _purchaseOrderRepository.GetPurchaseOrderDetailsByIdAsync(id);
            return podetails.ToList();
        }

        public async Task<int> RejectAndArchiveAsync(int id)
        {
            var postatus = await _purchaseOrderRepository.RejectAndArchiveAsync(id);
            return 1;
        }
    }
}
