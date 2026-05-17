using Humanizer;
using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using ManufacturingERP_Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManufacturingERP.Areas.User.Controllers
{    
    public class PurchaseOrderController : BaseController
    {
        private readonly ApplicationDBContext _context;
        private readonly ITrPORequirementService _trPORequirementService;
        private readonly IMaterialService _materialService;
        private readonly IPurchaseOrderService _purchaseOrderService;
        private readonly ISupplierService _supplierService;
        private readonly IStockService _stockService;
        public PurchaseOrderController(ApplicationDBContext context,
                                        ITrPORequirementService trPORequirementService,
                                        IMaterialService materialService,
                                        IPurchaseOrderService purchaseOrderService,
                                        ISupplierService supplierService,
                                        IStockService stockService)
        {
            _context = context;
            _trPORequirementService = trPORequirementService;
            _materialService = materialService;
            _purchaseOrderService = purchaseOrderService;
            _supplierService = supplierService;
            _stockService = stockService;
        }
        [HttpGet]
        // GET: User/PurchaseOrder
        public async Task<IActionResult> Index()
        {
            var model = new PurchaseOrderViewModel()
            {
                ListMPurchaseOrders = await _context.MPurchaseOrders.ToListAsync(),
                MMetarials = await _context.MMetarials.ToListAsync()
            };
            return View(model);
        }
        [HttpGet]
        // GET: User/PurchaseOrder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }          

            return View();
        }
        [HttpGet]
        // GET: User/PurchaseOrder/Create
        public async Task<IActionResult> Create()
        {
            //var materialDropdown = await _trPORequirementService.BindMaterialDropDown();

            var MateriualList = await _materialService.GetMaterialList();

            var Material = await _trPORequirementService.BindMaterialDropDown();
            var purchaseOrderId = await _purchaseOrderService.GetPurchaseOrderId();
            var PO_Number = await _purchaseOrderService.GetPONumberById();
            var SupplierName = await _purchaseOrderService.BindSupplierDropdown();

            ViewData["MaterialDD"] = Material;
            ViewBag.SupplierNames =new SelectList(SupplierName, "Value", "Text");

            var model= new PurchaseOrderViewModel()
            {
                MMetarials = MateriualList.Select(m=> new MMetarial
                {
                    PkMatId=m.PkMatId,
                    MatCode=m.MatCode,
                    MatName=m.MatName
                }).ToList(),
                MPurchaseOrder =new MPurchaseOrder()
                {
                    PO_ID=purchaseOrderId,
                    PO_Number= PO_Number
                }
            };
            return View(model);
        }

        // POST: User/PurchaseOrder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] PurchaseOrderViewModel purchaseOrderViewModel)
        {
            if (ModelState.IsValid)
            {
                var model = new PurchaseOrderViewModel()
                {
                    MPurchaseOrder = new MPurchaseOrder()
                    {
                        PO_Number = purchaseOrderViewModel.MPurchaseOrder.PO_Number,
                        PO_Date = purchaseOrderViewModel.MPurchaseOrder.PO_Date,
                        Supplier_ID = purchaseOrderViewModel.MPurchaseOrder.Supplier_ID,
                        Delivery_Date = purchaseOrderViewModel.MPurchaseOrder.Delivery_Date,
                        Payment_Terms = purchaseOrderViewModel.MPurchaseOrder.Payment_Terms,
                        Discount = purchaseOrderViewModel.MPurchaseOrder.Discount,
                        DiscountAmount = purchaseOrderViewModel.MPurchaseOrder.DiscountAmount,
                        GSTPercentage = purchaseOrderViewModel.MPurchaseOrder.GSTPercentage,
                        GSTAmount = purchaseOrderViewModel.MPurchaseOrder.GSTAmount,
                        TotalAmount = purchaseOrderViewModel.MPurchaseOrder.TotalAmount,
                        NetAmount = purchaseOrderViewModel.MPurchaseOrder.NetAmount,
                        Remark = purchaseOrderViewModel.MPurchaseOrder.Remark,
                        Currency = purchaseOrderViewModel.MPurchaseOrder.Currency,
                        PO_Status = purchaseOrderViewModel.MPurchaseOrder.PO_Status,
                        Created_By = User.Identity.Name,
                        Created_Date = DateTime.Now,
                        Approved_By = User.Identity.Name,
                        Approved_Date = DateTime.Now,
                        IsSyncronized = false
                    },

                    MPurchaseOrderDetails = new List<MPurchaseOrderDetails>()
                };

                var poId = await _purchaseOrderService.SavePurchaseOrderAsync(model);
                if (poId <= 0)
                {
                    ModelState.AddModelError("", "Failed to save purchase order");
                    return View(purchaseOrderViewModel);
                }
                else //(purchaseOrderViewModel.MPurchaseOrderDetails != null && purchaseOrderViewModel.MPurchaseOrderDetails.Any())
                {
                    var details = new MPurchaseOrderDetails();
                    //var model1 = model.MPurchaseOrderDetails;

                    var dto = new TrInventoryViewModel();

                    foreach (var item in purchaseOrderViewModel.MPurchaseOrderDetails)
                    {
                        model.MPurchaseOrderDetails.Add(new MPurchaseOrderDetails()
                        {
                            PO_ID = poId,
                            MaterialID = item.MaterialID,
                            MaterialCode = item.MaterialCode,
                            MaterialName = item.MaterialName,
                            UOM = item.UOM,
                            Quantity = item.Quantity,
                            Rate = item.Rate,
                            Amount = item.Amount
                        });
                    }

                    foreach (var item in purchaseOrderViewModel.MPurchaseOrderDetails)
                    {
                        // 🔥 STOCK UPDATE
                        dto = new TrInventoryViewModel()
                        {
                            MaterialId = item.MaterialID,
                            WarehouseId = 1,
                            LocationId = 1,
                            TransactionType = Convert.ToInt32(StockTransactionType.Purchase),
                            Quantity = item.Quantity
                        };
                    }

                    var result = await _purchaseOrderService.SavePurchaseOrderDetailsAsync(model);

                    var inventoryResult= await _stockService.UpdateInventoryAsync(dto);
                    if (result > 0 && inventoryResult > 0)
                    {
                        TempData["Action"] = "Create";
                        TempData["AlertMessage"] = "purchase order created SuccessFully.";
                        return RedirectToAction(nameof(Index));
                    }
                }               
            }
            return NotFound();
        } 
        
        [HttpGet]
        // GET: User/PurchaseOrder/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var purchaseOrder=await _purchaseOrderService.GetPurchaseOrderByIdAsync(id);
            var purchaseOrderDetails= await _purchaseOrderService.GetPurchaseOrderDetailsByIdAsync(id);
            var model = new PurchaseOrderViewModel()
            {
                MPurchaseOrder = new MPurchaseOrder()
                {
                    PO_ID = purchaseOrder.PO_ID,
                    PO_Number = purchaseOrder.PO_Number,
                    PO_Date = purchaseOrder.PO_Date,
                    Supplier_ID = purchaseOrder.Supplier_ID,
                    Delivery_Date = purchaseOrder.Delivery_Date,
                    Payment_Terms = purchaseOrder.Payment_Terms,
                    Discount = purchaseOrder.Discount,
                    DiscountAmount = purchaseOrder.DiscountAmount,
                    GSTPercentage = purchaseOrder.GSTPercentage,
                    GSTAmount = purchaseOrder.GSTAmount,
                    TotalAmount = purchaseOrder.TotalAmount,
                    NetAmount = purchaseOrder.NetAmount,
                    Remark = purchaseOrder.Remark,
                    Currency = purchaseOrder.Currency,
                    PO_Status = purchaseOrder.PO_Status
                },
                MPurchaseOrderDetails = new List<MPurchaseOrderDetails>()
                
            };

            // ✅ BIND COLLECTION HERE
            for (int i = 0; i < purchaseOrderDetails.Count; i++)
            {
                var d = purchaseOrderDetails[i];

                model.MPurchaseOrderDetails.Add(new MPurchaseOrderDetails
                {
                    PODetailID = d.PODetailID,
                    PO_ID = d.PO_ID,
                    MaterialID = d.MaterialID,
                    MaterialCode = d.MaterialCode,
                    MaterialName = d.MaterialName,
                    UOM = d.UOM,
                    Quantity = d.Quantity,
                    Rate = d.Rate,
                    Amount = d.Amount
                });
            }

            var SupplierName = await _purchaseOrderService.BindSupplierDropdown();
            var Material = await _trPORequirementService.BindMaterialDropDown();
            
            ViewData["MaterialDD"] = Material;
            ViewBag.SupplierNames = new SelectList(SupplierName, "Value", "Text");
            return View(model);
        }

        // POST: User/PurchaseOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id")] PurchaseOrderViewModel purchaseOrderViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseOrderViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseOrderViewModel);
        }
        [HttpGet]
        // GET: User/PurchaseOrder/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: User/PurchaseOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseOrderViewModelExists(int id)
        {
            return true; // _context.purchaseOrderViewModels.Any(e => e.id == id);
        }


        [HttpPost]
        public async Task<IActionResult> RejectPurchaseOrder(int id)
        {
            await _purchaseOrderService.RejectAndArchiveAsync(id);
            return Ok();
        }
    }
}
