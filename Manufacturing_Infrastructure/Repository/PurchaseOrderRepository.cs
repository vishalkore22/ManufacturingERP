using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Manufacturing_Infrastructure.Repository
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public PurchaseOrderRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetPurchaseOrderId()
        {
            var purchaseOrderId = await _dbContext.MPurchaseOrders.MaxAsync(x => (int?)x.PO_ID) == null ? 0 : await _dbContext.MPurchaseOrders.MaxAsync(x => (int?)x.PO_ID);
            if (purchaseOrderId >= 0 || purchaseOrderId == null)
            {
                int id = Convert.ToInt32(purchaseOrderId) + 1;
                return id;
            }
            return Convert.ToInt32(purchaseOrderId);
        }

        public async Task<string> GetPONumberById()
        {
            var purchaseOrderId = await _dbContext.MPurchaseOrders.MaxAsync(x => (int?)x.PO_ID) == null ? 0 : await _dbContext.MPurchaseOrders.MaxAsync(x => (int?)x.PO_ID);
            string id = "";
            if (purchaseOrderId == null || purchaseOrderId == 0)
            {
                id = "PO" + DateTime.Now.ToString("yyyy") + "-001";
                return id;
            }
            else
            {
                purchaseOrderId = purchaseOrderId + 1;
                id = "PO" + DateTime.Now.ToString("yyyy") + "-00" + purchaseOrderId;
                return id;
            }
        }

        public async Task<List<SelectListItem>> BindSupplierDropdown()
        {
            var supplierList = await _dbContext.MSuppliers
                                     .Select(c => new SelectListItem
                                     {
                                         Value = c.PkSupId.ToString(),
                                         Text = $"{c.PkSupId} - {c.SupplierName}"
                                     }).ToListAsync();
            if (supplierList != null)
            {
                return supplierList;
            }
            return null;
        }

        public async Task<int> SavePurchaseOrderAsync(PurchaseOrderViewModel model)
        {
            _dbContext.MPurchaseOrders.Add(model.MPurchaseOrder);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return model.MPurchaseOrder.PO_ID;
            }
            return 0;
            //if (result > 0)
            //{
            //    foreach (var item in model.MPurchaseOrderDetails)
            //    {
            //        item.PO_ID = model.MPurchaseOrder.PO_ID;
            //        _dbContext.MPurchaseOrderDetails.Add(item);
            //    }
            //    await _dbContext.SaveChangesAsync();
            //    return result;
            //}
            //else
            //{
            //    return 0;
            //}
        }

        public async Task<int> SavePurchaseOrderDetailsAsync(PurchaseOrderViewModel Model)
        {
            //_dbContext.MPurchaseOrderDetails.Add(Model.mPurchaseOrderDetails);
            foreach (var item in Model.MPurchaseOrderDetails)
            {
                _dbContext.MPurchaseOrderDetails.Add(item);
                //await _dbContext.SaveChangesAsync();
            }

            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return result;
            }

            return 0;
        }

        public async Task<MPurchaseOrder> GetPurchaseOrderByIdAsync(int id)
        {
            var porder = await (from c in _dbContext.MPurchaseOrders
                                where c.PO_ID == id
                                select new MPurchaseOrder
                                {
                                    PO_ID = c.PO_ID,
                                    PO_Number = c.PO_Number,
                                    PO_Date = c.PO_Date,
                                    Supplier_ID = c.Supplier_ID,
                                    Delivery_Date = c.Delivery_Date,
                                    Payment_Terms = c.Payment_Terms,
                                    Discount = c.Discount,
                                    DiscountAmount = c.DiscountAmount,
                                    GSTPercentage = c.GSTPercentage,
                                    GSTAmount = c.GSTAmount,
                                    TotalAmount = c.TotalAmount,
                                    NetAmount = c.NetAmount,
                                    Remark = c.Remark,
                                    Currency = c.Currency,
                                    PO_Status = c.PO_Status
                                }).FirstOrDefaultAsync();


            return porder;
        }

        public async Task<List<MPurchaseOrderDetails>> GetPurchaseOrderDetailsByIdAsync(int id)
        {
            var podetails = await (from c in _dbContext.MPurchaseOrderDetails
                                   where c.PO_ID == id
                                   select new MPurchaseOrderDetails
                                   {
                                       PODetailID = c.PODetailID,
                                       PO_ID = c.PO_ID,
                                       MaterialID = c.MaterialID,
                                       UOM = c.UOM,
                                       Quantity = c.Quantity,
                                       Rate = c.Rate,
                                       Amount = c.Amount
                                   }).ToListAsync();
            return podetails;
        }

        public async Task<int> RejectAndArchiveAsync(int id)
        {
            var po = _dbContext.MPurchaseOrders.Where(x => x.PO_ID == id);

            if (po == null) return 0;

            //// 1️⃣ Insert into Deleted table
            //var deletedPO = new MPurchaseOrderDeleted
            //{
            //    PO_ID = po.PO_ID,
            //    PO_Number = po.PO_Number,
            //    Supplier_ID = po.Supplier_ID,
            //    PO_Date = po.PO_Date,
            //    TotalAmount = po.TotalAmount,
            //    DeletedDate = DateTime.Now
            //};

            //_context.MPurchaseOrderDeleted.Add(deletedPO);

            //// 2️⃣ Update IsActive flag
            //po.IsActive = false;
            //po.PO_Status = "Rejected";

            //await _context.SaveChangesAsync();
            return 1;
        }
    }
}
