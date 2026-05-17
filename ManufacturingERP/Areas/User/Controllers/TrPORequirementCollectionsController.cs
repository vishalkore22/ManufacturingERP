using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using ManufacturingERP_Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManufacturingERP.Areas.User.Controllers
{    
    public class TrPORequirementCollectionsController : BaseController
    {
        private readonly ApplicationDBContext _context;
        private readonly ITrPORequirementService _trPORequirementService;
        private readonly ITrInventoryTransectionService _trInventoryTransectionService;
        public TrPORequirementCollectionsController(ApplicationDBContext context, ITrPORequirementService trPORequirementService, ITrInventoryTransectionService trInventoryTransectionService)
        {
            _context = context;
            _trPORequirementService = trPORequirementService;
            _trInventoryTransectionService = trInventoryTransectionService;
        }
        [HttpGet]
        // GET: User/TrPORequirementCollections
        public async Task<IActionResult> Index()
        {
            var model = await _trPORequirementService.GetRequirementCollectionAsync();
            return View(model);
        }

        [HttpGet]
        // GET: User/TrPORequirementCollections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trPORequirementCollection = await _context.TrPORequirementCollections
                .FirstOrDefaultAsync(m => m.PkRequirementID == id);
            if (trPORequirementCollection == null)
            {
                return NotFound();
            }

            return View(trPORequirementCollection);
        }
        [HttpGet]
        // GET: User/TrPORequirementCollections/Create
        public async Task<IActionResult> Create()
        {
            var reqId = await _trPORequirementService.GetRequirementIdAsync();            
            var woNum = await _trPORequirementService.GetWorkOrderNumber();
            var BillOfMat = await _trPORequirementService.GetBOMNumber();
            var model = new TrPORequirementCollection()
            {
                PkRequirementID = reqId,
                RequirementNumber = "RQ" + DateTime.Now.ToString("yyyy") + "-" + reqId,
                WorkOrderNumber = woNum,
                BOMNumber = BillOfMat
            };

            var materialDropdown = await _trPORequirementService.BindMaterialDropDown();

            if (materialDropdown != null)
            {
                ViewData["MaterialDD"] = materialDropdown;
                return View(model);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetMaterialQty(int MaterialID)
        {
            var qty = await _trInventoryTransectionService.GetMaterialQtyAsync(MaterialID);

            return Json(new { qty });
        }

        // POST: User/TrPORequirementCollections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkRequirementID,RequirementNumber,WorkOrderNumber,BOMNumber,MaterialID,MaterialCode,MatName,MatDescription,RequiredQty,Unit,StockAvailableQty,PurchaseQty,RequirementSource,RequiredDate,Priority,RequirementStatus,ApprovedBy,ApprovedDate,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,IsSynchronized")] TrPORequirementCollection trPORequirementCollection)
        {
            if (ModelState.IsValid)
            {
                var dropdownvalue = await _trPORequirementService.GetMatIdCodeNameAsync(trPORequirementCollection.MaterialID);
                
                var model = new TrPORequirementCollection()
                {
                    RequirementNumber = trPORequirementCollection.RequirementNumber,
                    TransDate = trPORequirementCollection.TransDate,
                    WorkOrderNumber = trPORequirementCollection.WorkOrderNumber,
                    BOMNumber = trPORequirementCollection.BOMNumber,
                    MaterialID = dropdownvalue.PkMatId,
                    MaterialCode = dropdownvalue.MatCode,
                    MatName = dropdownvalue.MatName,
                    MatDescription = trPORequirementCollection.MatDescription,
                    RequiredQty = trPORequirementCollection.RequiredQty,
                    Unit = trPORequirementCollection.Unit,
                    StockAvailableQty = Convert.ToInt32(dropdownvalue.MatQty),
                    PurchaseQty = trPORequirementCollection.PurchaseQty,
                    RequirementSource = trPORequirementCollection.RequirementSource,
                    RequiredDate = trPORequirementCollection.RequiredDate,
                    Priority = trPORequirementCollection.Priority,
                    RequirementStatus = trPORequirementCollection.RequirementStatus,
                    ApprovedBy = trPORequirementCollection.ApprovedBy,
                    ApprovedDate = trPORequirementCollection.ApprovedDate
                };
                var material = await _trPORequirementService.SaveRequirementCollection(model);
                if (material > 0)
                {
                    var trInventoryTransaction = await _trInventoryTransectionService.GetMaterialInformationByMatIdAsync(trPORequirementCollection.MaterialID);
                    int Qty = Convert.ToInt32(dropdownvalue.MatQty) - trPORequirementCollection.PurchaseQty;
                    var model1 = new TrInventoryTransaction()
                    {
                        PkInTransId = trInventoryTransaction.PkInTransId,
                        FkMatId = trInventoryTransaction.FkMatId,
                        TransType = trInventoryTransaction.TransType,
                        FkWarehouseId = trInventoryTransaction.FkWarehouseId,
                        Qty = trInventoryTransaction.Qty,
                        TransDate = trInventoryTransaction.TransDate,
                        LocationId = trInventoryTransaction.LocationId,
                        IsCreatedBy = trInventoryTransaction.IsCreatedBy,
                        CreatedDate = trInventoryTransaction.CreatedDate,
                        IsSynchronized = trInventoryTransaction.IsSynchronized,
                        MatName = trInventoryTransaction.MatName,
                        Warehouse = trInventoryTransaction.FkWarehouseId == 1 ? "p-1" : "p-2",
                        Location = trInventoryTransaction.LocationId == 1 ? "Pune" : "Mumbai"
                    };

                    var result = await _trInventoryTransectionService.UpdateTrInvTransactionAsync(model1);
                    if (result > 0)
                    {
                        TempData["Action"] = "Create";
                        TempData["AlertMessage"] = "Tr Po Requirement Collection Created Successfully";
                        return RedirectToAction(nameof(Index));
                    }
                    //TempData["Action"] = "Edit";
                    //TempData["AlertMessage"] = "Tr Po Requirement Collection Created Successfully";
                    //return RedirectToAction(nameof(Index));
                }    
            }
            return View(trPORequirementCollection);
        }

        // GET: User/TrPORequirementCollections/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }            
            var trPORequirementCollection = await _trPORequirementService.GetTrPORequirementCollectionById(id);
            var materialDropdown = await _trPORequirementService.BindMaterialDropDown();

            if (materialDropdown != null)
            {
                ViewData["MaterialDD"] = materialDropdown;
                return View(trPORequirementCollection);
            }
            if (trPORequirementCollection == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: User/TrPORequirementCollections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkRequirementID,RequirementNumber,WorkOrderNumber,BOMNumber,MaterialID,MaterialCode,MatName,MatDescription,RequiredQty,Unit,StockAvailableQty,PurchaseQty,RequirementSource,RequiredDate,Priority,RequirementStatus,ApprovedBy,ApprovedDate,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,IsSynchronized")] TrPORequirementCollection trPORequirementCollection)
        {
            if (id != trPORequirementCollection.PkRequirementID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var dropdownvalue = await _trPORequirementService.GetMatIdCodeNameAsync(trPORequirementCollection.MaterialID);
                    var model = new TrPORequirementCollection()
                    {
                        PkRequirementID=trPORequirementCollection.PkRequirementID,
                        RequirementNumber = trPORequirementCollection.RequirementNumber,
                        TransDate = trPORequirementCollection.TransDate,
                        WorkOrderNumber = trPORequirementCollection.WorkOrderNumber,
                        BOMNumber = trPORequirementCollection.BOMNumber,
                        MaterialID = dropdownvalue.PkMatId,
                        MaterialCode = dropdownvalue.MatCode,
                        MatName = dropdownvalue.MatName,
                        MatDescription = trPORequirementCollection.MatDescription,
                        RequiredQty = trPORequirementCollection.RequiredQty,
                        Unit = trPORequirementCollection.Unit,
                        StockAvailableQty = trPORequirementCollection.StockAvailableQty,
                        PurchaseQty = trPORequirementCollection.PurchaseQty,
                        RequirementSource = trPORequirementCollection.RequirementSource,
                        RequiredDate = trPORequirementCollection.RequiredDate,
                        Priority = trPORequirementCollection.Priority,
                        RequirementStatus = trPORequirementCollection.RequirementStatus,
                        ApprovedBy = trPORequirementCollection.ApprovedBy,
                        ApprovedDate = trPORequirementCollection.ApprovedDate
                    };

                    var update = await _trPORequirementService.UpdateTrRequirementCollectionAsync(model);
                    if (update > 0)
                    {
                        TempData["Action"] = "Edit";
                        TempData["AlertMessage"] = "Tr Po Requirement Collection Updated Successfully";
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrPORequirementCollectionExists(trPORequirementCollection.PkRequirementID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            return View(trPORequirementCollection);
        }
        [HttpGet]
        // GET: User/TrPORequirementCollections/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trPORequirementCollection = await _trPORequirementService.GetTrPORequirementCollectionById(id);
            var materialDropdown = await _trPORequirementService.BindMaterialDropDown();

            if (materialDropdown != null)
            {
                ViewData["MaterialDD"] = materialDropdown;
                return View(trPORequirementCollection);
            }
            if (trPORequirementCollection == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: User/TrPORequirementCollections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trPORequirementCollection = await _trPORequirementService.DeleteTrPORequirementCollectionByIdAsync(id);
            if (trPORequirementCollection != null)
            {
                TempData["Action"] = "Delete";
                TempData["AlertMessage"] = "Tr Po Requirement Collection Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
            
        }

        private bool TrPORequirementCollectionExists(int id)
        {
            return _context.TrPORequirementCollections.Any(e => e.PkRequirementID == id);
        }
    }
}
