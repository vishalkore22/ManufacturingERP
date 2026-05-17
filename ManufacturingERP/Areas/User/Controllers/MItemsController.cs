using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using Manufacturing_Core.ViewModels;
using Manufacturing_Infrastructure.Configuration;
using Microsoft.Extensions.Options;



namespace ManufacturingERP.Areas.User.Controllers
{
    public class MItemsController : BaseController
    {
        
        private readonly IItemService _itemService;
        private readonly ICategoryServices _categoryService;
        private readonly Appsettings _appSetting;
        private readonly IWebHostEnvironment _env;
        public MItemsController(IItemService itemService, ICategoryServices categoryServices, IWebHostEnvironment env, IOptions<Appsettings> appsetting)
        {
            _itemService = itemService;
            _categoryService = categoryServices;
            _appSetting = appsetting.Value;
        }
        [HttpGet]
        // GET: User/MItems
        public async Task<IActionResult> Index()
        {
            var ItemList = await _itemService.GetAllItemList();
            var model = new MItemViewModel
            {
                ListItems = ItemList
            };
            return View(model);
        }
        [HttpGet]
        // GET: User/MItems/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mItemDetails = await _itemService.GetItemById(id);
            var model = new MItemViewModel()
            {
                mItem = new MItem()
                {
                    PkItemId = mItemDetails.PkItemId,
                    ItemCode = mItemDetails.ItemCode,
                    ItemName = mItemDetails.ItemName,
                    FkCatId = mItemDetails.FkCatId,
                    ItemQty = mItemDetails.ItemQty,
                    ItemRate = mItemDetails.ItemRate,
                    Status = mItemDetails.Status,
                    HSNCODE = mItemDetails.HSNCODE,
                    SACODE = mItemDetails.SACODE,
                    ItemUnit = mItemDetails.ItemUnit,
                    ItemDescription = mItemDetails.ItemDescription
                }
            };
            if (model == null)
            {
                return NotFound();
            }
            var catList = await _categoryService.BindDropdownCategory();
            if (catList != null)
            {
                ViewData["FkCatId"] = catList;
                return View(model);
            }

            return NotFound();
        }
        [HttpGet]
        // GET: User/MItems/Create
        public async Task<IActionResult> Create()
        {
            var ItemCode1 = await _itemService.GetItemCode();
            var ItemsrNo = await _itemService.GetItemSerialNo();
            var catList = await _categoryService.BindDropdownCategory();
            if (ItemsrNo != null)
            {
                var model = new MItemViewModel()
                {
                    mItem=new MItem()
                    {
                        PkItemId=ItemsrNo,
                        ItemCode= ItemCode1
                    }
                };
                ViewData["FkCatId"] = catList;
                return View(model);
            }
            return NotFound();
            
        }

        // POST: User/MItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]        
        public async Task<IActionResult> Create([Bind] MItemViewModel mItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var CatName = await _categoryService.GetCategoryNameById(mItemViewModel.mItem.FkCatId);
                var itemList = new MItemViewModel()
                {
                    mItem = new MItem()
                    {
                        
                        ItemCode = mItemViewModel.mItem.ItemCode,
                        FkCatId = mItemViewModel.mItem.FkCatId,
                        CategoryName = CatName,
                        ItemName = mItemViewModel.mItem.ItemName,
                        ItemImageUrl = mItemViewModel.mItem.ItemImageUrl,
                        ItemDescription = mItemViewModel.mItem.ItemDescription,
                        ItemQty = mItemViewModel.mItem.ItemQty,
                        ItemRate = mItemViewModel.mItem.ItemRate,
                        ItemUnit = mItemViewModel.mItem.ItemUnit,
                        Status = mItemViewModel.mItem.Status,
                        HSNCODE = mItemViewModel.mItem.HSNCODE,
                        SACODE = mItemViewModel.mItem.SACODE,
                        TransDate = DateTime.Now,
                        IsCreatedBy = "",
                        CreateDate = DateTime.Now,
                        IsSynchronized = false
                    }
                };

                //var _imagePath = Path.Combine(_env.WebRootPath, "image");
                //if (!Directory.Exists(_imagePath))
                //    Directory.CreateDirectory(_imagePath);

                var Itemresult = await _itemService.SaveItemDetails(itemList);
                if (Itemresult > 0)
                {
                    TempData["Action"] = "Create";
                    TempData["AlertMessage"] = "Item Saved Successfully";
                    return RedirectToAction(nameof(Index));
                }
                
            }
            var catList = await _categoryService.BindDropdownCategory();
            if (catList != null)
            {
                ViewData["FkCatId"] = catList;
                return View();
            }
            return NotFound();
        }
        [HttpGet]
        // GET: User/MItems/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mItem = await _itemService.GetItemById(id); 
            if (mItem == null)
            {
                return NotFound();
            }
            var catList = await _categoryService.BindDropdownCategory();
            if (mItem != null)
            {
                var model = new MItemViewModel()
                {
                    mItem = new MItem()
                    {
                        PkItemId = mItem.PkItemId,
                        ItemCode = mItem.ItemCode,
                        FkCatId = mItem.FkCatId,
                        ItemName = mItem.ItemName,
                        ItemImageUrl=mItem.ItemImageUrl,
                        ItemDescription = mItem.ItemDescription,
                        ItemQty = mItem.ItemQty,
                        ItemRate = mItem.ItemRate,
                        ItemUnit = mItem.ItemUnit,
                        Status = mItem.Status,
                        HSNCODE = mItem.HSNCODE,
                        SACODE = mItem.SACODE

                    }
                };
                ViewData["FkCatId"] = catList;
                return View(model);
            }
            return NotFound();
        }

        // POST: User/MItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind] MItemViewModel mItemViewModel)
        {
            if (id != mItemViewModel.mItem.PkItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var CatName = await _categoryService.GetCategoryNameById(mItemViewModel.mItem.FkCatId);
                try
                {
                    var itemList = new MItemViewModel()
                    {
                        mItem = new MItem()
                        {
                            PkItemId=mItemViewModel.mItem.PkItemId,
                            ItemCode = mItemViewModel.mItem.ItemCode,
                            FkCatId = mItemViewModel.mItem.FkCatId,
                            CategoryName=CatName,
                            ItemName = mItemViewModel.mItem.ItemName,
                            ItemImageUrl=mItemViewModel.mItem.ItemImageUrl,
                            ItemDescription = mItemViewModel.mItem.ItemDescription,
                            ItemQty = mItemViewModel.mItem.ItemQty,
                            ItemRate = mItemViewModel.mItem.ItemRate,
                            ItemUnit = mItemViewModel.mItem.ItemUnit,
                            Status = mItemViewModel.mItem.Status,
                            HSNCODE = mItemViewModel.mItem.HSNCODE,
                            SACODE = mItemViewModel.mItem.SACODE,
                            TransDate = DateTime.Now,
                            IsCreatedBy = "",
                            CreateDate = DateTime.Now,
                            IsSynchronized = false
                        }
                    };

                    var itemresult = await _itemService.UpdateItemDetails(itemList);
                    if (itemresult > 0)
                    {
                        TempData["Action"] = "Edit";
                        TempData["AlertMessage"] = "Item Updated Successfully";
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MItemExists(mItemViewModel.mItem.PkItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return NotFound();
            }
            var catList = await _categoryService.BindDropdownCategory();
            if (catList != null)
            {
                ViewData["FkCatId"] = catList;                
            }
            return View();
        }
        [HttpGet]
        // GET: User/MItems/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mItem = await _itemService.GetItemById(id);
            if (mItem == null)
            {
                return NotFound();
            }
            var catList = await _categoryService.BindDropdownCategory();
            if (mItem != null)
            {
                var model = new MItemViewModel()
                {
                    mItem = new MItem()
                    {
                        PkItemId = mItem.PkItemId,
                        ItemCode = mItem.ItemCode,
                        FkCatId = mItem.FkCatId,
                        ItemName = mItem.ItemName,
                        ItemImageUrl=mItem.ItemImageUrl,
                        ItemDescription = mItem.ItemDescription,
                        ItemQty = mItem.ItemQty,
                        ItemRate = mItem.ItemRate,
                        ItemUnit = mItem.ItemUnit,
                        Status = mItem.Status,
                        HSNCODE = mItem.HSNCODE,
                        SACODE = mItem.SACODE

                    }
                };
                ViewData["FkCatId"] = catList;
                return View(model);
            }
            return NotFound();
        }

        // POST: User/MItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mItem = await _itemService.DeleteItemDetails(id);
            if (mItem != null)
            {
                TempData["Action"] = "Delete";
                TempData["AlertMessage"] = "Item Details deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private bool MItemExists(int id)
        {
            return true; 
        }
        //[HttpGet]
        //public async Task<IActionResult> Add()
        //{
        //    var item = _appSetting.FileName;
        //    var DownloadedLink = _appSetting.FileUploadPath;
        //    var model = new MItemViewModel()
        //    {
        //        mItemDtls = new MItemDetails()
        //        {
        //            FileName= item,
        //            DownloadLink = DownloadedLink
        //        }
        //    };
            
        //    return View(model.mItemDtls);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Upload(IFormFile imageFile)
        //{
        //    var _imagePath = Path.Combine(_env.WebRootPath, "image");
        //    if (imageFile != null && imageFile.Length > 0)
        //    {
        //        var filename = Path.GetFileName(imageFile.FileName);
        //        var savepath = Path.Combine(_imagePath, filename);

        //        using (var stream = new FileStream(savepath, FileMode.Create))
        //        {
        //            await imageFile.CopyToAsync(stream);
        //        }

        //        TempData["Upload"] = "Upload";
        //        TempData["AlertMessage"] = "File Uploaded Successfully.";

        //    }
        //    return View("Create");
        //}
    }
}
