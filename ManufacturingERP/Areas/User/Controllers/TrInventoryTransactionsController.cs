using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace ManufacturingERP.Areas.User.Controllers
{    
    public class TrInventoryTransactionsController : BaseController
    {
        private readonly ApplicationDBContext _context;
        private readonly ITrInventoryTransectionService _trInventoryTransectionService;
        private readonly ITrPORequirementService _trPORequirementService;
        public TrInventoryTransactionsController(ApplicationDBContext context, 
                                                 ITrInventoryTransectionService trInventoryTransectionService,
                                                 ITrPORequirementService trPORequirementService)
        {
            _context = context;
            _trInventoryTransectionService = trInventoryTransectionService;
            _trPORequirementService = trPORequirementService;
        }

        [HttpGet]
        // GET: User/TrInventoryTransactions
        public async Task<IActionResult> Index()
        {
            var model = await _trInventoryTransectionService.GetInventoryAsync();
            return View(model);
        }
        
        [HttpGet]
        // GET: User/TrInventoryTransactions/Create
        public async Task<IActionResult> Create()
        {
            var InvId = await _trInventoryTransectionService.GetPkInventoryIdAsync();
            var model = new TrInventoryTransaction()
            {
                PkInTransId = InvId,
            };
            //var Material1 = await _trInventoryTransectionService.BindMaterialDropDownAsync();
            var Material = await _trPORequirementService.BindMaterialDropDown();
            ViewData["FkMatId"] = Material;
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> GetMaterialQty(int FkMatId)
        {
            var qty = await _trInventoryTransectionService.GetMaterialQtyByFkMatIdAsync(FkMatId);
            
            return Json(new { qty });
        }


        // POST: User/TrInventoryTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkInTransId,FkMatId,TransType,FkWarehouseId,Qty,TransDate,LocationId,IsCreatedBy,CreatedDate,IsUpdatedBy,UpdatedDate,IsSynchronized")] TrInventoryTransaction trInventoryTransaction)
        {
            if (ModelState.IsValid)
            {
                var matname = await _trInventoryTransectionService.GetMaterialNameByMatIdAsync(trInventoryTransaction.FkMatId);

                var model = new TrInventoryTransaction()
                {
                    FkMatId = trInventoryTransaction.FkMatId,
                    TransType = trInventoryTransaction.TransType,
                    FkWarehouseId = trInventoryTransaction.FkWarehouseId,
                    Qty = trInventoryTransaction.Qty,
                    TransDate = trInventoryTransaction.TransDate,
                    LocationId = trInventoryTransaction.LocationId,
                    IsCreatedBy = trInventoryTransaction.IsCreatedBy,
                    CreatedDate = trInventoryTransaction.CreatedDate,
                    IsSynchronized = trInventoryTransaction.IsSynchronized,
                    MatName= matname,
                    Warehouse= trInventoryTransaction.FkWarehouseId==1? "p-1" : "p-2",
                    Location= trInventoryTransaction.LocationId ==1 ? "Pune" : "Mumbai"
                };

                var trTransInv = await _trInventoryTransectionService.SaveInventoryTransAsync(model);
                if (trTransInv > 0)
                {
                    TempData["Action"] = "Create";
                    TempData["AlertMessage"] = " Tr Inventory transection saved SuccessFully.";
                    return RedirectToAction(nameof(Index));
                }
                
            }
            ViewData["FkMatId"] = new SelectList(_context.MMetarials, "PkMatId", "MatName", trInventoryTransaction.FkMatId);
            return View(trInventoryTransaction);
        }
        [HttpGet]
        // GET: User/TrInventoryTransactions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trInventoryTransaction = await _trInventoryTransectionService.GetTrInventoryTransactionByIdAsync(id);
            if (trInventoryTransaction == null)
            {
                return NotFound();
            }
            var Material = await _trPORequirementService.BindMaterialDropDown();
            ViewData["FkMatId"] = Material;

            return View(trInventoryTransaction);
        }

        // POST: User/TrInventoryTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkInTransId,FkMatId,TransType,FkWarehouseId,Qty,TransDate,LocationId,IsCreatedBy,CreatedDate,IsUpdatedBy,UpdatedDate,IsSynchronized")] TrInventoryTransaction trInventoryTransaction)
        {
            if (id != trInventoryTransaction.PkInTransId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var matname = await _trInventoryTransectionService.GetMaterialNameByMatIdAsync(trInventoryTransaction.FkMatId);
                    var model = new TrInventoryTransaction()
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
                        MatName = matname,
                        Warehouse = trInventoryTransaction.FkWarehouseId == 1 ? "p-1" : "p-2",
                        Location = trInventoryTransaction.LocationId == 1 ? "Pune" : "Mumbai"
                    };

                    var result = await _trInventoryTransectionService.UpdateTrInvTransactionAsync(model);
                    if (result > 0)
                    {
                        TempData["Action"] = "Edit";
                        TempData["AlertMessage"] = "Inventory transection Updated SuccessFully.";
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrInventoryTransactionExists(trInventoryTransaction.PkInTransId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkMatId"] = new SelectList(_context.MMetarials, "PkMatId", "MatName", trInventoryTransaction.FkMatId);
            return View(trInventoryTransaction);
        }
        [HttpGet]
        // GET: User/TrInventoryTransactions/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Material = await _trPORequirementService.BindMaterialDropDown();
            ViewData["FkMatId"] = Material;
            var trInventoryTransaction = await _trInventoryTransectionService.GetTrInventoryTransactionByIdAsync(id);


            return View(trInventoryTransaction);            
        }

        // POST: User/TrInventoryTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventorydelete = await _trInventoryTransectionService.DeleteInventoryTransectionAsync(id);
            if (inventorydelete == null)
            {
                return NotFound();
            }
            else
            {
                TempData["Action"] = "Delete";
                TempData["AlertMessage"] = "Inventory Transection Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
        }

        private bool TrInventoryTransactionExists(int id)
        {
            return _context.TrInventoryTransaction.Any(e => e.PkInTransId == id);
        }
    }
}
