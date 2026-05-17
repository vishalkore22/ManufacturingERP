using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManufacturingERP_Application.Interfaces;
using Manufacturing_Core.ViewModels;
using Manufacturing_Core.Entity;
namespace ManufacturingERP.Areas.User.Controllers
{
    
    public class MSubcategoriesController : BaseController
    {         
        private readonly ISubcategoryService _subcategoryService;
        private readonly ICategoryServices _categoryServices;
        private readonly ITypeService _typeService;
        public MSubcategoriesController(ISubcategoryService subcategoryService, ICategoryServices categoryServices, ITypeService typeService)
        {
            _subcategoryService = subcategoryService;
            _categoryServices = categoryServices;
            _typeService = typeService;
        }

        // GET: User/MSubcategories
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var subCateDetails = await _subcategoryService.GetAllSubcategory();
            var subcategoryModel = new MSubcategoryViewModel()
            {
                ListMCategory = subCateDetails
            };
            return View(subcategoryModel);
        }

        // GET: User/MSubcategories/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mSubcategory = await _subcategoryService.GetSubcategoryById(id);
            var model = new Manufacturing_Core.ViewModels.MSubcategoryViewModel()
            {
                mSubcategory = mSubcategory
            };
            var typeList = await _categoryServices.BindDropDownType();
            var catList = await _categoryServices.BindDropdownCategory();
            if (model != null)
            {
                ViewData["FkTypeId"] = typeList;
                ViewData["FkCatId"] = catList;
                return View(model);
            }
            if (mSubcategory == null)
            {
                return NotFound();
            }

            return View();
        }

        // GET: User/MSubcategories/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var srNo = await _subcategoryService.GetSubCategorySrNo();
            var subcategorycode = await _subcategoryService.GetSubCategoryCodeAsync();
            var model = new MSubcategoryViewModel()
            {
                mSubcategory = new MSubcategory()
                {
                    PkSubCatId = srNo,
                    SubCategoryCode = subcategorycode
                }
            };
            var typeList = await _categoryServices.BindDropDownType();
            var catList = await _categoryServices.BindDropdownCategory();
            if (typeList != null)
            {
                ViewData["FkTypeId"] = typeList;
                ViewData["FkCatId"] = catList;
                return View(model);
            }
            return View();
        }

        // POST: User/MSubcategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] MSubcategoryViewModel mSubcategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                
                var Subcat = new Manufacturing_Core.ViewModels.MSubcategoryViewModel()
                {
                    mSubcategory = new Manufacturing_Core.Entity.MSubcategory()
                    {
                        SubCategoryCode = mSubcategoryViewModel.mSubcategory.SubCategoryCode,
                        FkTypeId = mSubcategoryViewModel.mSubcategory.FkTypeId,                        
                        FkCatId = mSubcategoryViewModel.mSubcategory.FkCatId,                        
                        SubCategoryName = mSubcategoryViewModel.mSubcategory.SubCategoryName,
                        SubCategoryDescription = mSubcategoryViewModel.mSubcategory.SubCategoryName,
                        IsCreatedBy = "",
                        CreateDate = DateTime.Now,
                        IsSynchronized = false
                    }
                };
                var subcatResu = await _subcategoryService.SaveSubCategorydetails(Subcat);
                if (subcatResu > 0)
                {
                    TempData["Action"] = "Create";
                    TempData["AlertMessage"] = "Subcategory Information Created successfully.";
                    return RedirectToAction(nameof(Index));
                }
                
            }
            var typeList = await _categoryServices.BindDropDownType();
            var catList = await _categoryServices.BindDropdownCategory();
            if (typeList != null)
            {
                ViewData["FkTypeId"] = typeList;
                ViewData["FkCatId"] = catList;
            }
            return View();
        }

        // GET: User/MSubcategories/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var mSubcategory1 = await _subcategoryService.GetSubcategoryById(id);           
            
            var typeList = await _categoryServices.BindDropDownType();
            var catList = await _categoryServices.BindDropdownCategory();
            if (mSubcategory1 != null)
            {
                var model = new MSubcategoryViewModel()
                {
                    mSubcategory = new MSubcategory()
                    {
                        PkSubCatId = mSubcategory1.PkSubCatId,
                        SubCategoryCode = mSubcategory1.SubCategoryCode,
                        FkTypeId = mSubcategory1.FkTypeId,
                        FkCatId = mSubcategory1.FkTypeId,
                        SubCategoryName = mSubcategory1.SubCategoryName,
                        SubCategoryDescription = mSubcategory1.SubCategoryDescription
                    }
                };
                ViewData["FkTypeId"] = typeList;
                ViewData["FkCatId"] = catList;
                return View(model);
            }
            return View();
        }

        // POST: User/MSubcategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind]MSubcategoryViewModel mSubcategoryViewModel)
        {
            if (id != mSubcategoryViewModel.mSubcategory.PkSubCatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var Subcat = new MSubcategoryViewModel()
                    {
                        mSubcategory = new MSubcategory()
                        {
                            PkSubCatId=mSubcategoryViewModel.mSubcategory.PkSubCatId,
                            SubCategoryCode = mSubcategoryViewModel.mSubcategory.SubCategoryCode,
                            FkTypeId = mSubcategoryViewModel.mSubcategory.FkTypeId,                            
                            FkCatId = mSubcategoryViewModel.mSubcategory.FkCatId,                            
                            SubCategoryName = mSubcategoryViewModel.mSubcategory.SubCategoryName,
                            SubCategoryDescription = mSubcategoryViewModel.mSubcategory.SubCategoryDescription,
                            IsUpdatedBy = "",
                            UpdateDate = DateTime.Now,
                            IsSynchronized = false
                        }
                    };
                    var subcatResu = await _subcategoryService.UpdateSubCategorydetails(Subcat);
                    if (subcatResu > 0)
                    {
                        TempData["Action"] = "Edit";
                        TempData["AlertMessage"] = "Subcategory Information Updated successfully.";
                        return RedirectToAction(nameof(Index));
                    }
                    var typeList = await _categoryServices.BindDropDownType();
                    var catList = await _categoryServices.BindDropdownCategory();
                    if (typeList != null)
                    {
                        ViewData["FkTypeId"] = typeList;
                        ViewData["FkCatId"] = catList;                        
                    }
                    return View();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MSubcategoryExists(mSubcategoryViewModel.mSubcategory.PkSubCatId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }                
            }
            return View();
        }

        // GET: User/MSubcategories/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mSubcategory1 = await _subcategoryService.GetSubcategoryById(id);
            var model = new MSubcategoryViewModel()
            {
                mSubcategory = new MSubcategory()
                {
                    PkSubCatId = mSubcategory1.PkSubCatId,
                    SubCategoryCode = mSubcategory1.SubCategoryCode,
                    FkTypeId = mSubcategory1.FkTypeId,
                    FkCatId = mSubcategory1.FkTypeId,
                    SubCategoryName = mSubcategory1.SubCategoryName,
                    SubCategoryDescription = mSubcategory1.SubCategoryDescription
                }
            };
            
            var typeList = await _categoryServices.BindDropDownType();
            var catList = await _categoryServices.BindDropdownCategory();
            if (typeList != null)
            {
                ViewData["FkTypeId"] = typeList;
                ViewData["FkCatId"] = catList;
                return View(model);
            }
            return View();           
        }

        // POST: User/MSubcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleteSub = await _subcategoryService.DeleteSubCategoryDetailsByIdAsync(id);
            if (deleteSub > 0)
            {
                TempData["Action"] = "Delete";
                TempData["AlertMessage"] = "Subcategory Information Deleted successfully.";
                return RedirectToAction(nameof(Index));
            }            
            
            return View();
        }

        private bool MSubcategoryExists(int id)
        {
            return true;//_context.MSubcategory.Any(e => e.PkSubCatId == id);
        }
    }
}
