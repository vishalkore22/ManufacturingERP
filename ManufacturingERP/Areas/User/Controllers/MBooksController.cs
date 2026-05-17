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
    
    public class MBooksController : BaseController
    {
        private readonly ApplicationDBContext _context;

        public MBooksController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: User/MBooks
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.MBooks.Include(m => m.MAuthor);
            return View(await applicationDBContext.ToListAsync());
        }
        [HttpGet]
        // GET: User/MBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mBooks = await _context.MBooks
                .Include(m => m.MAuthor)
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (mBooks == null)
            {
                return NotFound();
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "Bio");
            return View(mBooks);
        }
        [HttpGet]
        // GET: User/MBooks/Create
        public async Task<IActionResult> Create()
        {
            var id = await _context.MBooks.MaxAsync(x => (int?)x.BookID) == null ? 0 : await _context.MBooks.MaxAsync(x => x.BookID);
            int Bookid = id + 1;
            var model = new MBooks()
            {
                BookID= Bookid,
                PublishedDate=DateTime.Now
                
            };
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "Bio");
            return View(model);
            
            
        }

        // POST: User/MBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID,Title,AuthorID,PublishedDate")] MBooks mBooks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mBooks);
                var result= await _context.SaveChangesAsync();
                if (result > 0)
                {
                    TempData["Action"] = "Create";
                    TempData["AlertMessage"] = "Books Information Created successfully.";
                    return RedirectToAction(nameof(Index));
                }
                
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "Bio", mBooks.AuthorID);
            return View(mBooks);
        }
        [HttpGet]
        // GET: User/MBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mBooks = await _context.MBooks.FindAsync(id);
            var book = new MBooks()
            {
                BookID = mBooks.BookID,
                Title = mBooks.Title,
                AuthorID = mBooks.AuthorID,
                PublishedDate = mBooks.PublishedDate

            };
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "Bio", mBooks.AuthorID);
            return View(book);
        }

        // POST: User/MBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookID,Title,AuthorID,PublishedDate")] MBooks mBooks)
        {
            if (id != mBooks.BookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mBooks);                   
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        TempData["Action"] = "Edit";
                        TempData["AlertMessage"] = "Book Information Updated successfully.";
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MBooksExists(mBooks.BookID))
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
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "Bio", mBooks.AuthorID);
            return View(mBooks);
        }
        [HttpGet]
        // GET: User/MBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mBooks = await _context.MBooks
                .Include(m => m.MAuthor)
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (mBooks == null)
            {
                return NotFound();
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "Bio", mBooks.AuthorID);
            return View(mBooks);
        }

        // POST: User/MBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mBooks = await _context.MBooks.FindAsync(id);
            if (mBooks != null)
            {
                _context.MBooks.Remove(mBooks);
            }

            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                TempData["Action"] = "Delete";
                TempData["AlertMessage"] = "Books Information Deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private bool MBooksExists(int id)
        {
            return _context.MBooks.Any(e => e.BookID == id);
        }
    }
}
