using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manufacturing_Core.Entity;

namespace ManufacturingERP.Areas.User.Controllers
{
    [Area("User")]
    public class MProductsController : BaseController
    {
        private readonly ApplicationDBContext _context;

        public MProductsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: User/MProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.MProducts.ToListAsync());
        }

        // GET: User/MProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mProduct = await _context.MProducts
                .FirstOrDefaultAsync(m => m.PkProdId == id);
            if (mProduct == null)
            {
                return NotFound();
            }

            return View(mProduct);
        }

        // GET: User/MProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/MProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkProdId,ProdCode,ProdName,ProdDescription,ProdQty,ProductRate,ProdImage,IsCreatedBy,CreateDate,IsUpdatedBy,UpdateDate,IsSynchronized")] MProduct mProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mProduct);
        }

        // GET: User/MProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mProduct = await _context.MProducts.FindAsync(id);
            if (mProduct == null)
            {
                return NotFound();
            }
            return View(mProduct);
        }

        // POST: User/MProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkProdId,ProdCode,ProdName,ProdDescription,ProdQty,ProductRate,ProdImage,IsCreatedBy,CreateDate,IsUpdatedBy,UpdateDate,IsSynchronized")] MProduct mProduct)
        {
            if (id != mProduct.PkProdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MProductExists(mProduct.PkProdId))
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
            return View(mProduct);
        }

        // GET: User/MProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mProduct = await _context.MProducts
                .FirstOrDefaultAsync(m => m.PkProdId == id);
            if (mProduct == null)
            {
                return NotFound();
            }

            return View(mProduct);
        }

        // POST: User/MProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mProduct = await _context.MProducts.FindAsync(id);
            if (mProduct != null)
            {
                _context.MProducts.Remove(mProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MProductExists(int id)
        {
            return _context.MProducts.Any(e => e.PkProdId == id);
        }
    }
}
