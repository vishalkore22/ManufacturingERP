using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;

namespace ManufacturingERP.Areas.User.Controllers
{
    
    public class TrStockGoodsAsPerSuppliersController : BaseController
    {
        private readonly ApplicationDBContext _context;

        private readonly ITrStockGoodsAsPerSuppliersService _service;

        public TrStockGoodsAsPerSuppliersController(ApplicationDBContext context,
                                                        ITrStockGoodsAsPerSuppliersService service)
        {
            _context = context;
            _service = service;
        }

        // GET: User/TrStockGoodsAsPerSuppliers
        public async Task<IActionResult> Index()
        {
            //var model= await _service.
            return View();
        }

        // GET: User/TrStockGoodsAsPerSuppliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trStockGoodsAsPerSupplier = await _context.TrStockGoodsAsPerSuppliers
                .FirstOrDefaultAsync(m => m.PkStGoodsId == id);
            if (trStockGoodsAsPerSupplier == null)
            {
                return NotFound();
            }

            return View(trStockGoodsAsPerSupplier);
        }

        // GET: User/TrStockGoodsAsPerSuppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/TrStockGoodsAsPerSuppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkStGoodsId,FkSupId,FkMatId,FkWarehouseId,LocationId,Qty,CheckedDate,UnitMeasurement,IsCreatedBy,CreatedDate,IsUpdatedBy,UpdatedDate,IsSynchronized")] TrStockGoodsAsPerSupplier trStockGoodsAsPerSupplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trStockGoodsAsPerSupplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trStockGoodsAsPerSupplier);
        }

        // GET: User/TrStockGoodsAsPerSuppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trStockGoodsAsPerSupplier = await _context.TrStockGoodsAsPerSuppliers.FindAsync(id);
            if (trStockGoodsAsPerSupplier == null)
            {
                return NotFound();
            }
            return View(trStockGoodsAsPerSupplier);
        }

        // POST: User/TrStockGoodsAsPerSuppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkStGoodsId,FkSupId,FkMatId,FkWarehouseId,LocationId,Qty,CheckedDate,UnitMeasurement,IsCreatedBy,CreatedDate,IsUpdatedBy,UpdatedDate,IsSynchronized")] TrStockGoodsAsPerSupplier trStockGoodsAsPerSupplier)
        {
            if (id != trStockGoodsAsPerSupplier.PkStGoodsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trStockGoodsAsPerSupplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrStockGoodsAsPerSupplierExists(trStockGoodsAsPerSupplier.PkStGoodsId))
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
            return View(trStockGoodsAsPerSupplier);
        }

        // GET: User/TrStockGoodsAsPerSuppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trStockGoodsAsPerSupplier = await _context.TrStockGoodsAsPerSuppliers
                .FirstOrDefaultAsync(m => m.PkStGoodsId == id);
            if (trStockGoodsAsPerSupplier == null)
            {
                return NotFound();
            }

            return View(trStockGoodsAsPerSupplier);
        }

        // POST: User/TrStockGoodsAsPerSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trStockGoodsAsPerSupplier = await _context.TrStockGoodsAsPerSuppliers.FindAsync(id);
            if (trStockGoodsAsPerSupplier != null)
            {
                _context.TrStockGoodsAsPerSuppliers.Remove(trStockGoodsAsPerSupplier);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrStockGoodsAsPerSupplierExists(int id)
        {
            return _context.TrStockGoodsAsPerSuppliers.Any(e => e.PkStGoodsId == id);
        }
    }
}
