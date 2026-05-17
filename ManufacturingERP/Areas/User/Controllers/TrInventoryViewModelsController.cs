using Humanizer;
using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using ManufacturingERP_Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ManufacturingERP.Areas.User.Controllers
{    
    public class TrInventoryViewModelsController : BaseController
    {
        private readonly ApplicationDBContext _context;
        private readonly ITrInventoryServices _iTrInventoryServices;
        
        public TrInventoryViewModelsController(ApplicationDBContext context,
                                                ITrInventoryServices trInventoryServices)
        {
            _context = context;
            _iTrInventoryServices = trInventoryServices;            
        }
        [HttpGet]
        // GET: User/TrInventoryViewModels
        public async Task<IActionResult> Index()
        {
            var model = await _iTrInventoryServices.GetTrInventoryViewModel();
            return View(model);
        }
        [HttpGet]
        // GET: User/TrInventoryViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trInventoryViewModel = await _context.TrInventoryViewModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trInventoryViewModel == null)
            {
                return NotFound();
            }

            return View(trInventoryViewModel);
        }
        [HttpGet]
        // GET: User/TrInventoryViewModels/Create
        public async Task<IActionResult> Create()
        {
            
            ViewData["LocationId"] = new SelectList(_context.MLocations, "LocationId", "LocationName");
            ViewData["MaterialId"] = new SelectList(_context.MMetarials, "PkMatId", "MatName");
            ViewData["WarehouseId"] = new SelectList(_context.MWarehouses, "PkWarehouseId", "WarehouseName");
            return View();
        }

        // POST: User/TrInventoryViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaterialId,WarehouseId,LocationId,TransactionType,Quantity")] TrInventoryViewModel trInventoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _iTrInventoryServices.CreateTrInventoryViewModelAsync(trInventoryViewModel);
                TempData["Action"] = "Create";
                TempData["AlertMessage"] = "Stock maintained successfully.";
                return RedirectToAction("Index");
            }
            return View(trInventoryViewModel);
        }
        [HttpGet]
        // GET: User/TrInventoryViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trInventoryViewModel = await _context.TrInventoryViewModels.FindAsync(id);
            if (trInventoryViewModel == null)
            {
                return NotFound();
            }
            return View(trInventoryViewModel);
        }

        // POST: User/TrInventoryViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaterialId,WarehouseId,LocationId,TransactionType,Quantity")] TrInventoryViewModel trInventoryViewModel)
        {
            if (id != trInventoryViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trInventoryViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrInventoryViewModelExists(trInventoryViewModel.Id))
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
            return View(trInventoryViewModel);
        }
        [HttpGet]
        // GET: User/TrInventoryViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trInventoryViewModel = await _context.TrInventoryViewModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trInventoryViewModel == null)
            {
                return NotFound();
            }

            return View(trInventoryViewModel);
        }

        // POST: User/TrInventoryViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trInventoryViewModel = await _context.TrInventoryViewModels.FindAsync(id);
            if (trInventoryViewModel != null)
            {
                _context.TrInventoryViewModels.Remove(trInventoryViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrInventoryViewModelExists(int id)
        {
            return _context.TrInventoryViewModels.Any(e => e.Id == id);
        }
    }
}
