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
    
    public class TrRequirementCollectionsController : BaseController
    {
        private readonly ApplicationDBContext _context;
        private readonly ITrRequirementCollectionsService _trRequirementCollectionsService;
        public TrRequirementCollectionsController(ApplicationDBContext context,
                            ITrRequirementCollectionsService trRequirementCollectionsService)
        {
            _trRequirementCollectionsService = trRequirementCollectionsService;
            _context = context;
        }
        [HttpGet]
        // GET: User/TrRequirementCollections
        public async Task<IActionResult> Index()
        {
            var requirementCollections = await _trRequirementCollectionsService.GetAllRequirementCollectionsAsync();
            return View(requirementCollections);
        }
        [HttpGet]
        // GET: User/TrRequirementCollections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trRequirementCollection = await _context.TrRequirementCollections
                .FirstOrDefaultAsync(m => m.RequirementCollectionId == id);
            if (trRequirementCollection == null)
            {
                return NotFound();
            }

            return View(trRequirementCollection);
        }
        [HttpGet]
        // GET: User/TrRequirementCollections/Create
        public async Task<IActionResult> Create()
        {
            //var jobId= await _trRequirementCollectionsService.
            return View();
        }

        // POST: User/TrRequirementCollections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequirementCollectionId,DepartmentId,DepartmentName,JobId,Designation,NumberOfEmployeesRequired,SelectionCriteria,ExperienceRequired,SkillsRequired,JobDescription,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,IsSynchronized")] TrRequirementCollection trRequirementCollection)
        {
            if (ModelState.IsValid)
            {

                //var model= new TrRequirementCollection()
                //{
                    
                //}
                //_context.Add(trRequirementCollection);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return View(trRequirementCollection);
        }
        [HttpGet]
        // GET: User/TrRequirementCollections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trRequirementCollection = await _context.TrRequirementCollections.FindAsync(id);
            if (trRequirementCollection == null)
            {
                return NotFound();
            }
            return View(trRequirementCollection);
        }

        // POST: User/TrRequirementCollections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequirementCollectionId,DepartmentId,DepartmentName,JobId,Designation,NumberOfEmployeesRequired,SelectionCriteria,ExperienceRequired,SkillsRequired,JobDescription,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,IsSynchronized")] TrRequirementCollection trRequirementCollection)
        {
            if (id != trRequirementCollection.RequirementCollectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trRequirementCollection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrRequirementCollectionExists(trRequirementCollection.RequirementCollectionId))
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
            return View(trRequirementCollection);
        }
        [HttpGet]
        // GET: User/TrRequirementCollections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trRequirementCollection = await _context.TrRequirementCollections
                .FirstOrDefaultAsync(m => m.RequirementCollectionId == id);
            if (trRequirementCollection == null)
            {
                return NotFound();
            }

            return View(trRequirementCollection);
        }

        // POST: User/TrRequirementCollections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trRequirementCollection = await _context.TrRequirementCollections.FindAsync(id);
            if (trRequirementCollection != null)
            {
                _context.TrRequirementCollections.Remove(trRequirementCollection);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrRequirementCollectionExists(int id)
        {
            return _context.TrRequirementCollections.Any(e => e.RequirementCollectionId == id);
        }
    }
}
