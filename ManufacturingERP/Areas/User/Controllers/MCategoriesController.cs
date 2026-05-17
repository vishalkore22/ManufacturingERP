using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using Manufacturing_Core.ViewModels;

namespace ManufacturingERP.Areas.User.Controllers
{
    
    public class MCategoriesController : BaseController
    {
        private readonly ICategoryServices _categoryServices;
        private readonly ITypeService _typeService;
        public MCategoriesController(ICategoryServices categoryServices, ITypeService typeService)
        {
            _categoryServices = categoryServices;
            _typeService = typeService;
        }
        [HttpGet]
        // GET: User/MCategories
        public async Task<IActionResult> Index()
        {

            var CategoryDetails = await _categoryServices.GetCategoryDetails();
            var model = new MCategoryViewModel()
            {
                ListMCategory=CategoryDetails 
            };
            if (model != null)
            {
                return View(model);
            }
            return null;
        }

        // GET: User/MCategories/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mCategory = await _categoryServices.GetCategoryDetailsById(id);
            var model = new MCategoryViewModel()
            {
               mCategory = mCategory
            };
            var typeList = await _categoryServices.BindDropDownType();
           
            if (model != null)
            {
                ViewData["FkTypeId"] = typeList;
                return View(model);                
            }
            if (mCategory == null)
            {
                return NotFound();
            }
            return View();
        }

        // GET: User/MCategories/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var srNo = await _categoryServices.GetCategorySrNo();
            var Categorycode = await _categoryServices.GetCategoryCodeAsync();
            var model = new MCategoryViewModel()
            {
                mCategory = new MCategory()
                {
                    PkCatId = srNo,
                    CategoryCode = Categorycode
                }
            };
            var typeList = await _categoryServices.BindDropDownType();
            if (typeList != null)
            {
                ViewData["FkTypeId"] = typeList;
                return View(model);
            }
            return NotFound();
        }

        // POST: User/MCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] MCategoryViewModel mCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var Mcategory = new MCategoryViewModel()
                {
                    mCategory = new MCategory()
                    {
                        CategoryCode = mCategoryViewModel.mCategory.CategoryCode,
                        FkTypeId = mCategoryViewModel.mCategory.FkTypeId,
                        TypeName = await _typeService.GetTypeNameById(mCategoryViewModel.mCategory.FkTypeId),
                        CategoryName = mCategoryViewModel.mCategory.CategoryName,
                        CategoryDescription = mCategoryViewModel.mCategory.CategoryDescription,
                        TransDate=DateTime.Now,
                        IsCreatedBy = "",
                        CreateDate = DateTime.Now,
                        IsSynchronized = false
                    }
                };
                var CategoryResult = await _categoryServices.SaveCategoryDetails(Mcategory);
                if (CategoryResult > 0)
                {
                    TempData["Action"] = "Create";
                    TempData["AlertMessage"] = "Category Information Created successfully.";
                    return RedirectToAction(nameof(Index));
                }    
            }
            var typeList = await _categoryServices.BindDropDownType();
            if (typeList != null)
            {
                ViewData["FkTypeId"] = typeList;
                return View();
            }

            return View();
        }

        // GET: User/MCategories/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mcategory = await _categoryServices.GetCategoryDetailsById(id);
            var model = new MCategoryViewModel()
            {
                mCategory = new MCategory()
                {
                    PkCatId=mcategory.PkCatId,
                    CategoryCode = mcategory.CategoryCode,
                    FkTypeId = mcategory.FkTypeId,
                    CategoryName = mcategory.CategoryName,
                    CategoryDescription = mcategory.CategoryDescription,
                                        
                }
            };
            if (mcategory == null)
            {
                return NotFound();
            }
            var typeList = await _categoryServices.BindDropDownType();
            if (typeList != null)
            {
                ViewData["FkTypeId"] = typeList;
                //return View();
            }
            if (model != null)
            {
                return View(model);
            }
            return View();
        }

        // POST: User/MCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind] MCategoryViewModel mCategoryViewModel)
        {
            if (id !=mCategoryViewModel.mCategory.PkCatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var Mcategory = new MCategoryViewModel()
                    {
                        mCategory = new MCategory()
                        {
                            PkCatId=mCategoryViewModel.mCategory.PkCatId,
                            CategoryCode=mCategoryViewModel.mCategory.CategoryCode,
                            FkTypeId=mCategoryViewModel.mCategory.FkTypeId,
                            TypeName = await _typeService.GetTypeNameById(mCategoryViewModel.mCategory.FkTypeId),
                            CategoryName =mCategoryViewModel.mCategory.CategoryName,
                            CategoryDescription=mCategoryViewModel.mCategory.CategoryDescription,
                            IsUpdatedBy = "",
                            UpdateDate = DateTime.Now,
                            IsSynchronized = false
                        }
                    };
                    var catresult = await _categoryServices.UpdateCategoryDetails(Mcategory);
                    if (catresult > 0)
                    {
                        TempData["Action"] = "Edit";
                        TempData["AlertMessage"] = "Category Information Updated successfully.";
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MCategoryExists(mCategoryViewModel.mCategory.PkCatId))
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
            var typeList = await _categoryServices.BindDropDownType();
            if (typeList != null)
            {
                ViewData["FkTypeId"] = typeList;
                return View();
            }
            return NotFound();
        }

        // GET: User/MCategories/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mcategory = await _categoryServices.GetCategoryDetailsById(id);
            var model = new MCategoryViewModel()
            {
                mCategory = new MCategory()
                {
                    PkCatId=mcategory.PkCatId,
                    CategoryCode = mcategory.CategoryCode,
                    FkTypeId = mcategory.FkTypeId,
                    CategoryName = mcategory.CategoryName,
                    CategoryDescription = mcategory.CategoryDescription,

                }
            };
            if (mcategory == null)
            {
                return NotFound();
            }
            var typeList = await _categoryServices.BindDropDownType();
            if (typeList != null)
            {
                ViewData["FkTypeId"] = typeList;
                //return View();
            }
            if (model != null)
            {
                return View(model);
            }
            return View();
        }

        // POST: User/MCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleteCategory = await _categoryServices.GetCategoryDetailsById(id);
            if (deleteCategory is not null)
            {
                var deleteAddress = await _categoryServices.DeleteAddressInfo(id);
                if (deleteAddress > 0)
                {
                    TempData["Action"] = "Delete";
                    TempData["AlertMessage"] = "Category Details deleted successfully.";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        private bool MCategoryExists(int id)
        {
            return true;//_context.MCategory.Any(e => e.PkCatId == id);
        }
    }
}
