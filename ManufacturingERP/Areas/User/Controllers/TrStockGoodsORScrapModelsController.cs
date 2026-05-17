using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;

namespace ManufacturingERP.Areas.User.Controllers
{
    public class TrStockGoodsORScrapModelsController : BaseController
    {
        private readonly ApplicationDBContext _context;
        
        private readonly ITrStockGoodsORScrapServices _trStockGoodsORScrapServices; 

        public TrStockGoodsORScrapModelsController(ApplicationDBContext context, 
                                                    ITrStockGoodsORScrapServices trStockGoodsORScrapServices)
        {
            _context = context;            
            _trStockGoodsORScrapServices= trStockGoodsORScrapServices;
        }

        [HttpGet]
        // GET: User/TrStockGoodsORScrapModels
        public async Task<IActionResult> Index()
        {
            var model= await _trStockGoodsORScrapServices.GetStockGoodsORScrapsAsync();
            
            return View(model);
        }

        [HttpGet]
        // GET: User/TrStockGoodsORScrapModels/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goods = new List<SelectListItem>
            {
                new SelectListItem { Text= "Goods", Value="1"},
                new SelectListItem { Text="Scrap", Value="0"}
            };

            ViewBag.goods = new SelectList(goods, "Value", "Text", "0");

            ViewData["LocationId"] = new SelectList(_context.MLocations, "LocationId", "LocationName");
            ViewData["MaterialId"] = new SelectList(_context.MMetarials, "PkMatId", "MatName");
            ViewData["PkWarehouseId"] = new SelectList(_context.MWarehouses, "PkWarehouseId", "WarehouseName");
            var trStockGoodsORScrapModels = await _trStockGoodsORScrapServices.GetEntityByIdAsync(id);
            if (trStockGoodsORScrapModels == null)
            {
                return NotFound();
            }

            return View(trStockGoodsORScrapModels);
        }

        [HttpGet]
        // GET: User/TrStockGoodsORScrapModels/Create
        public async Task<IActionResult> Create()
        {
            var id = await _trStockGoodsORScrapServices.GetEntity();
            var model = new TrStockGoodsORScrap()
            {
                PkStGoodScrapId = id
            };

            var goods = new List<SelectListItem>
            {
                new SelectListItem { Text= "Goods", Value="1"},
                new SelectListItem { Text="Scrap", Value="0"}
            };

            ViewBag.goods = new SelectList(goods, "Value", "Text", "0");

            ViewData["LocationId"] = new SelectList(_context.MLocations, "LocationId", "LocationName");
            ViewData["MaterialId"] = new SelectList(_context.MMetarials, "PkMatId", "MatName");
            ViewData["PkWarehouseId"] = new SelectList(_context.MWarehouses, "PkWarehouseId", "WarehouseName");
            return View(model);
        }

        // POST: User/TrStockGoodsORScrapModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkStGoodScrapId,FkMatId,FkWarehouseId,LocationId,Qty,CheckedDate,UnitMeasurement,FlagGoodsOrScrap")] TrStockGoodsORScrap trStockGoodsORScrap)
        {
            if (ModelState.IsValid)
            {
                var model = new TrStockGoodsORScrap()
                {
                    FkMatId = trStockGoodsORScrap.FkMatId,
                    FkWarehouseId = trStockGoodsORScrap.FkWarehouseId,
                    LocationId = trStockGoodsORScrap.LocationId,
                    Qty = trStockGoodsORScrap.Qty,
                    CheckedDate = trStockGoodsORScrap.CheckedDate,
                    UnitMeasurement = trStockGoodsORScrap.UnitMeasurement,
                    FlagGoodsOrScrap = trStockGoodsORScrap.FlagGoodsOrScrap,
                    IsCreatedBy="",
                    CreatedDate=DateTime.Now,
                    IsUpdatedBy="",
                    UpdatedDate=DateTime.Now,
                    IsSynchronized=false,
                };
                var result = await _trStockGoodsORScrapServices.SaveAsync(model);    
                
                if (result > 0)
                {
                    TempData["Action"] = "Create";
                    TempData["AlertMessage"] = "Goods/Scraps saved successfully.";
                    return RedirectToAction(nameof(Index));
                }                
            }
            return View(trStockGoodsORScrap);
        }

        [HttpGet]
        // GET: User/TrStockGoodsORScrapModels/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trStockGoodsORScrapModels = await _trStockGoodsORScrapServices.GetEntityByIdAsync(id);
            if (trStockGoodsORScrapModels == null)
            {
                return NotFound();
            }
            var goods = new List<SelectListItem>
            {
                new SelectListItem { Text= "Goods", Value="1"},
                new SelectListItem { Text="Scrap", Value="0"}
            };
            ViewBag.goods = new SelectList(goods, "Value", "Text", "0");

            ViewData["LocationId"] = new SelectList(_context.MLocations, "LocationId", "LocationName");
            ViewData["MaterialId"] = new SelectList(_context.MMetarials, "PkMatId", "MatName");
            ViewData["PkWarehouseId"] = new SelectList(_context.MWarehouses, "PkWarehouseId", "WarehouseName");
            return View(trStockGoodsORScrapModels);
        }

        // POST: User/TrStockGoodsORScrapModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkStGoodScrapId,FkMatId,FkWarehouseId,LocationId,Qty,CheckedDate,UnitMeasurement,FlagGoodsOrScrap,IsCreatedBy,CreatedDate,IsUpdatedBy,UpdatedDate,IsSynchronized")] TrStockGoodsORScrap trStockGoodsORScrapModels)
        {
            if (id != trStockGoodsORScrapModels.PkStGoodScrapId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var update = await _trStockGoodsORScrapServices.UpdateAsync(trStockGoodsORScrapModels);
                    if (update != null)
                    {
                        TempData["Action"] = "Edit";
                        TempData["AlertMessage"] = "Goods/Scraps Updated successfully.";
                        return RedirectToAction(nameof(Index));
                    }                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrStockGoodsORScrapModelsExists(trStockGoodsORScrapModels.PkStGoodScrapId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            return View(trStockGoodsORScrapModels);
        }

        [HttpGet]
        // GET: User/TrStockGoodsORScrapModels/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trStockGoodsORScrapModels = await _trStockGoodsORScrapServices.GetEntityByIdAsync(id);
            if (trStockGoodsORScrapModels == null)
            {
                return NotFound();
            }

            var goods = new List<SelectListItem>
            {
                new SelectListItem { Text= "Goods", Value="1"},
                new SelectListItem { Text="Scrap", Value="0"}
            };
            ViewBag.goods = new SelectList(goods, "Value", "Text", "0");

            ViewData["LocationId"] = new SelectList(_context.MLocations, "LocationId", "LocationName");
            ViewData["MaterialId"] = new SelectList(_context.MMetarials, "PkMatId", "MatName");
            ViewData["PkWarehouseId"] = new SelectList(_context.MWarehouses, "PkWarehouseId", "WarehouseName");

            return View(trStockGoodsORScrapModels);
        }

        // POST: User/TrStockGoodsORScrapModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {            
            if (id != null)
            {
                var result= await _trStockGoodsORScrapServices.DeleteAsync(id);
                if (result != null)
                {
                    TempData["Action"] = "Delete";
                    TempData["AlertMessage"] = "Goods/Scraps Deleted Successfully.";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        private bool TrStockGoodsORScrapModelsExists(int id)
        {
            return _context.TrStockGoodsORScrap.Any(e => e.PkStGoodScrapId == id);
        }
    }
}
