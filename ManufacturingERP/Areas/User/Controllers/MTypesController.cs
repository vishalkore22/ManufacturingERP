using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using ManufacturingERP_Application.Services;

namespace ManufacturingERP.Areas.User.Controllers
{    
    public class MTypesController : BaseController
    {
        private readonly ITypeService _typeService;

        public MTypesController(ITypeService typeService)
        {
            _typeService = typeService;
        }
        [HttpGet]
        // GET: User/MTypes
        public async Task<IActionResult> Index()
        {
            var type = await _typeService.GetAllType();
            return View(type);
        }
        [HttpGet]
        // GET: User/MTypes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var TypeDetails = await _typeService.GetTypeByIdAsync(id);
            if (TypeDetails != null)
            {
                return View(TypeDetails);
            }
            return NotFound();
        }
        [HttpGet]
        // GET: User/MTypes/Create
        public async Task<IActionResult> Create()
        {
            var PkType = await _typeService.GetTypeIdAsync();
            var typeId = await _typeService.GetTypeCode();
            var model = new MType()
            {
                PkTypeId=Convert.ToInt32(PkType),
                TypeCode = typeId
            };
            return View(model);
        }

        // POST: User/MTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkTypeId,TypeCode,TypeName,TypeDescription,TransDate,IsCreatedBy,CreatedDate,IsUpdatedBy,UpdatedDate,IsSynchronized")] MType mType)
        {
            if (ModelState.IsValid)
            {
               
                var Mtype = new MType()
                {                    
                    TypeCode = mType.TypeCode,
                    TypeName = mType.TypeName,
                    TypeDescription = mType.TypeDescription,
                    TransDate = DateTime.Now,
                    IsCreatedBy = "",
                    CreatedDate = DateTime.Now,
                    IsSynchronized = false
                };
                var type = await _typeService.SaveMTypeAsync(Mtype);
                
                if (type > 0)
                {
                    TempData["Action"] = "Create";
                    TempData["AlertMessage"] = "Type created SuccessFully.";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(mType);
        }
        
        [HttpGet]
        // GET: User/MTypes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _typeService.GetTypeByIdAsync(id);

            
            if (model is not null)
            {                
                return View(model);
            }
            return View();            
        }

        // POST: User/MTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkTypeId,TypeCode,TypeName,TypeDescription,TransDate,IsCreatedBy,CreatedDate,IsUpdatedBy,UpdatedDate,IsSynchronized")] MType mType)
        {
            if (id != mType.PkTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var Mtype = new MType()
                    {
                        PkTypeId=mType.PkTypeId,
                        TypeCode = mType.TypeCode,
                        TypeName = mType.TypeName,
                        TypeDescription = mType.TypeDescription,
                        IsUpdatedBy = "",
                        UpdatedDate = DateTime.Now,
                        IsSynchronized=false
                    };
                    var type = await _typeService.UpdateTypeDetailsAsync(Mtype);
                    if (type > 0)
                    {
                        TempData["Action"] = "Edit";
                        TempData["AlertMessage"] = "Type Details updated SuccessFully.";
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MTypeExists(mType.PkTypeId))
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
            return View(mType);
        }
        [HttpGet]
        // GET: User/MTypes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _typeService.GetTypeByIdAsync(id);

            if (model is not null)
            {
                return View(model);
            }


            return View();
        }

        // POST: User/MTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bankDetails = await _typeService.DeleteTypeDetailsAsync(id);
            if (bankDetails > 0)
            {
                TempData["Action"] = "Delete";
                TempData["AlertMessage"] = "Type Details deleted SuccessFully.";
                return RedirectToAction(nameof(Index));
            }
            return View();
            
        }

        private bool MTypeExists(int id)
        {
            return true;
        }
    }
}
