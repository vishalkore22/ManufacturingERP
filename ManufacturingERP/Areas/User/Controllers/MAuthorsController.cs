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
    
    public class MAuthorsController : BaseController
    {
        private readonly ApplicationDBContext _context;

        public MAuthorsController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        // GET: User/MAuthors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Authors.ToListAsync());
        }
        [HttpGet]
        // GET: User/MAuthors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mAuthors = await _context.Authors
                .FirstOrDefaultAsync(m => m.AuthorID == id);
            if (mAuthors == null)
            {
                return NotFound();
            }

            return View(mAuthors);
        }
        [HttpGet]
        // GET: User/MAuthors/Create
        public async Task<IActionResult> Create()
        {
            var id = await _context.Authors.MaxAsync(x => (int?)x.AuthorID) == null ? 0 : await _context.Authors.MaxAsync(x => x.AuthorID);
            int AutorId = id + 1;
            var model = new MAuthors()
            {
                AuthorID = AutorId,
               
            };
            return View(model);
        }

        // POST: User/MAuthors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorID,Name,Bio")] MAuthors mAuthors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mAuthors);
                var result=await _context.SaveChangesAsync();
                if (result > 0)
                {
                    TempData["Action"] = "Create";
                    TempData["AlertMessage"] = "Author Information Created successfully.";
                    return RedirectToAction(nameof(Index));
                }                
            }
            return View(mAuthors);
        }
        [HttpGet]
        // GET: User/MAuthors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mAuthors = await _context.Authors.FindAsync(id);
            if (mAuthors == null)
            {
                return NotFound();
            }
            return View(mAuthors);
        }

        // POST: User/MAuthors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorID,Name,Bio")] MAuthors mAuthors)
        {
            if (id != mAuthors.AuthorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mAuthors);
                    var result =await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        TempData["Action"] = "Edit";
                        TempData["AlertMessage"] = "Author Information Updated successfully.";
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MAuthorsExists(mAuthors.AuthorID))
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
            return View(mAuthors);
        }
        [HttpGet]
        // GET: User/MAuthors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mAuthors = await _context.Authors
                .FirstOrDefaultAsync(m => m.AuthorID == id);
            if (mAuthors == null)
            {
                return NotFound();
            }

            return View(mAuthors);
        }

        // POST: User/MAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mAuthors = await _context.Authors.FindAsync(id);
            if (mAuthors != null)
            {
                _context.Authors.Remove(mAuthors);
            }
            var result= await _context.SaveChangesAsync();
            if (result > 0)
            {
                TempData["Action"] = "Delete";
                TempData["AlertMessage"] = "Author Information Deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool MAuthorsExists(int id)
        {
            return _context.Authors.Any(e => e.AuthorID == id);
        }

        //public async Task<IActionResult> Cancel()
        //{
         
        //}
    }
}
