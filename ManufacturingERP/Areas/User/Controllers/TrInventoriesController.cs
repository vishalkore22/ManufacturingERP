using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace ManufacturingERP.Areas.User.Controllers
{    
    public class TrInventoriesController : BaseController
    {
        private readonly ApplicationDBContext _context;
        private readonly IInventoryService _inventory;
        
        public TrInventoriesController(ApplicationDBContext context, 
                                        IInventoryService inventoryService)
        {
            _context = context;
            _inventory = inventoryService;            
        }
        [HttpGet]
        // GET: User/TrInventories
        public async Task<IActionResult> Index()
        {
            //var model = new TrInventoryViewModel
            //{
            //    Materials = await _stockService.GetMaterials(),
            //    Warehouses = await _stockService.GetWarehouses(),
            //    Locations = await _stockService.GetLocations()
            //};

            var model = await _inventory.GetInventoryViewModel();
            return View(model);
        }
        [HttpGet]
        // GET: User/TrInventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trInventory = await _context.TrInventories
                .Include(t => t.Location)
                .Include(t => t.Material)
                .FirstOrDefaultAsync(m => m.MaterialId == id);
            if (trInventory == null)
            {
                return NotFound();
            }

            return View(trInventory);
        }
        [HttpGet]
        // GET: User/TrInventories/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.MLocations, "LocationId", "LocationName");
            ViewData["MaterialId"] = new SelectList(_context.MMetarials, "PkMatId", "MatName");
            ViewData["PkWarehouseId"] =new SelectList(_context.MWarehouses, "PkWarehouseId", "WarehouseName");
            return View();
        }

        // POST: User/TrInventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransId,MaterialId,WarehouseId,LocationId,TransactionType,Quantity,UnitId,Rate,TransactionDate,ReferenceId,ReferenceType,Remarks,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,IsSynchronized")] TrInventory trInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.MLocations, "LocationId", "LocationName", trInventory.LocationId);
            ViewData["MaterialId"] = new SelectList(_context.MMetarials, "PkMatId", "MatName", trInventory.MaterialId);
            return View(trInventory);
        }
        [HttpGet]
        // GET: User/TrInventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trInventory = await _context.TrInventories.FindAsync(id);
            if (trInventory == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.MLocations, "LocationId", "LocationName", trInventory.LocationId);
            ViewData["MaterialId"] = new SelectList(_context.MMetarials, "PkMatId", "MatName", trInventory.MaterialId);
            return View(trInventory);
        }

        // POST: User/TrInventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransId,MaterialId,WarehouseId,LocationId,TransactionType,Quantity,UnitId,Rate,TransactionDate,ReferenceId,ReferenceType,Remarks,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,IsSynchronized")] TrInventory trInventory)
        {
            if (id != trInventory.MaterialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trInventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrInventoryExists(trInventory.MaterialId))
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
            ViewData["LocationId"] = new SelectList(_context.MLocations, "LocationId", "LocationName", trInventory.LocationId);
            ViewData["MaterialId"] = new SelectList(_context.MMetarials, "PkMatId", "MatName", trInventory.MaterialId);
            return View(trInventory);
        }
        [HttpGet]
        // GET: User/TrInventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trInventory = await _context.TrInventories
                .Include(t => t.Location)
                .Include(t => t.Material)
                .FirstOrDefaultAsync(m => m.MaterialId == id);
            if (trInventory == null)
            {
                return NotFound();
            }

            return View(trInventory);
        }

        // POST: User/TrInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trInventory = await _context.TrInventories.FindAsync(id);
            if (trInventory != null)
            {
                _context.TrInventories.Remove(trInventory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrInventoryExists(int id)
        {
            return _context.TrInventories.Any(e => e.MaterialId == id);
        }
    }
}
