using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;

namespace ManufacturingERP.Areas.User.Controllers
{    
    public class MMetarialsController : BaseController
    {        
        private readonly IMaterialService _materialService;
        public MMetarialsController(IMaterialService materialService)
        {
            _materialService = materialService; 
        }
        [HttpGet]
        // GET: User/MMetarials
        public async Task<IActionResult> Index()
        {
            var model = await _materialService.GetMaterialList();
            if (model != null)
            {
                return View(model);
            }
            return View();
        }
        [HttpGet]
        // GET: User/MMetarials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var mMetarial = await _context.MMetarials
            //    .FirstOrDefaultAsync(m => m.PkMatId == id);
            //if (mMetarial == null)
            //{
            //    return NotFound();
            //}

            return View();
        }
        [HttpGet]
        // GET: User/MMetarials/Create
        public async Task<IActionResult> Create()
        {
            var materialId = await _materialService.GetMaterialId();
            //var MaterialCode = await _materialService.GetMaterialCodeById();
            var model = new MMetarial()
            {
                PkMatId = (int)materialId
                //MatCode = MaterialCode
            };
            return View(model);
        }

        // POST: User/MMetarials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkMatId,MatCode,MatName,MatDescription,MatQty,MatRate,MatUnit,HSNCode,SACode,TransDate,IsCreatedBy,CreateDate,IsUpdatedBy,UpdateDate,IsSynchronized")] MMetarial mMetarial)
        {
            if (ModelState.IsValid)
            {
                var model = new MMetarial()
                {
                    PkMatId = mMetarial.PkMatId,
                    MatCode = mMetarial.MatCode,
                    MatName = mMetarial.MatName,
                    MatDescription = mMetarial.MatDescription,
                    MatQty = mMetarial.MatQty,
                    MatRate = mMetarial.MatRate,
                    MatUnit = mMetarial.MatUnit,
                    HSNCode = mMetarial.HSNCode,
                    SACode = mMetarial.SACode,
                    TransDate = DateTime.Now,
                    IsCreatedBy = mMetarial.IsCreatedBy,
                    CreateDate = DateTime.Now,
                    IsUpdatedBy = mMetarial.IsUpdatedBy,
                    UpdateDate = DateTime.Now,
                    IsSynchronized = false
                };
                var savematerial = await _materialService.SaveMaterialasync(model);
                if (savematerial > 0)
                {
                    TempData["Action"] = "Create";
                    TempData["AlertMessage"] = "Material created SuccessFully.";
                    return RedirectToAction(nameof(Index));
                }                
            }
            return View(mMetarial);
        }

        // GET: User/MMetarials/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mMetarial = await _materialService.GetmaterialByIdAsync(id);
            if (mMetarial == null)
            {
                return NotFound();
            }
            return View(mMetarial);
        }

        // POST: User/MMetarials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkMatId,MatCode,MatName,MatDescription,MatQty,MatRate,MatUnit,HSNCode,SACode,TransDate,IsCreatedBy,CreateDate,IsUpdatedBy,UpdateDate,IsSynchronized")] MMetarial mMetarial)
        {
            if (id != mMetarial.PkMatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var material = new MMetarial()
                    {
                        PkMatId = mMetarial.PkMatId,
                        MatCode = mMetarial.MatCode,
                        MatName = mMetarial.MatName,
                        MatDescription = mMetarial.MatDescription,
                        MatQty = mMetarial.MatQty,
                        MatRate = mMetarial.MatRate,
                        MatUnit = mMetarial.MatUnit,
                        HSNCode = mMetarial.HSNCode,
                        SACode = mMetarial.SACode,
                        TransDate = DateTime.Now,
                        IsCreatedBy = mMetarial.IsCreatedBy,
                        CreateDate = DateTime.Now,
                        IsUpdatedBy = mMetarial.IsUpdatedBy,
                        UpdateDate = DateTime.Now,
                        IsSynchronized = false
                    };
                    var updateMaterial = await _materialService.UpdatematerialAsync(material);
                    if (updateMaterial > 0)
                    {
                        TempData["Action"] = "Edit";
                        TempData["AlertMessage"] = "Material updated SuccessFully.";
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MMetarialExists(mMetarial.PkMatId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }                
            }
            return View(mMetarial);
        }
        [HttpGet]
        // GET: User/MMetarials/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mMetarial = await _materialService.GetmaterialByIdAsync(id);
            if (mMetarial == null)
            {
                return NotFound();
            }

            return View(mMetarial);
        }

        // POST: User/MMetarials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mMetarial = await _materialService.GetmaterialByIdAsync(id);
            if (mMetarial != null)
            {
                var mMaterialId = await _materialService.DeleteMaterialByIdAsync(mMetarial);
                if (mMaterialId > 0)
                {
                    TempData["Action"] = "Delete";
                    TempData["AlertMessage"] = "Material deleted SuccessFully.";
                    return RedirectToAction(nameof(Index));
                }
            }            
            return View();
        }

        private bool MMetarialExists(int id)
        {
            return false;
        }
    }
}
