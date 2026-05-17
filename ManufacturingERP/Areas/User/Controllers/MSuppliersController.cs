using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP.Areas.User.Models;
using ManufacturingERP_Application.Interfaces;
using ManufacturingERP_Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ManufacturingERP.Areas.User.Controllers
{    
    public class MSuppliersController : BaseController
    {
        private readonly ApplicationDBContext _context;
        private readonly ISupplierService _supplierService;
        private readonly ILedgerService _ledgerService;
        public MSuppliersController(ApplicationDBContext context, ISupplierService supplierService, ILedgerService ledgerService)
        {
            _context = context;
            _supplierService = supplierService;
            _ledgerService = ledgerService;
        }
        [HttpGet]
        // GET: User/MSuppliers
        public async Task<IActionResult> Index()
        {
            var supplier=await _supplierService.GetSupplierInfo();
            var model = new Manufacturing_Core.ViewModels.MSupplierViewModel()
            {
                MSuppliersList= supplier
            };
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string username = User.Identity.Name;

            ViewBag.UserId = userId;
            ViewBag.Username = username;    
            return View(model);
        }
        [HttpGet]
        // GET: User/MSuppliers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mSupplierViewModel = await _supplierService.GetSupplierInfoById(id);
            var mSupplierAddress = await _supplierService.GetSupplierAddressById(id);
            if (mSupplierViewModel == null)
            {
                return NotFound();
            }
            else
            {
                var model = new Manufacturing_Core.ViewModels.MSupplierViewModel()
                {
                    MSupplier = new MSupplier()
                    {
                        PkSupId = mSupplierViewModel.PkSupId,
                        SupplierCode = mSupplierViewModel.SupplierCode == null ? "" : mSupplierViewModel.SupplierCode,
                        SupplierName = mSupplierViewModel.SupplierName == null ? "" : mSupplierViewModel.SupplierName,
                        ShortName = mSupplierViewModel.ShortName == null ? "" : mSupplierViewModel.ShortName,
                        LicenceId = mSupplierViewModel.LicenceId == null ? "" : mSupplierViewModel.LicenceId,
                        VATNo = mSupplierViewModel.VATNo == null ? "" : mSupplierViewModel.VATNo,
                        CSTNo = mSupplierViewModel.CSTNo == null ? "" : mSupplierViewModel.CSTNo,
                        TINno = mSupplierViewModel.TINno == null ? "" : mSupplierViewModel.TINno,
                        GSTIn = mSupplierViewModel.GSTIn == null ? "" : mSupplierViewModel.GSTIn,
                        IsCreatedBy = "Vishal",
                        CreatedDate = DateTime.Now,
                        IsUpdatedBy = "Vishal",
                        UpdatedDate = DateTime.Now,
                        IsSynchronized = false
                    },
                    mAddress = new MAddress()
                    {
                        Name = mSupplierAddress.Name,
                        CurrentAddress = mSupplierAddress.CurrentAddress,
                        CurrentAddressLine1 = mSupplierAddress.CurrentAddressLine1,
                        CurrentAddressLine2 = mSupplierAddress.CurrentAddressLine2,
                        Country = mSupplierAddress.Country,
                        State = mSupplierAddress.State,
                        City = mSupplierAddress.City,
                        Pin = mSupplierAddress.Pin,
                        PhNo = mSupplierAddress.PhNo,
                        PermAddress = mSupplierAddress.PermAddress,
                        PermAddressLine1 = mSupplierAddress.PermAddressLine1,
                        PermAddressLine2 = mSupplierAddress.PermAddressLine2,
                        PermCountry = mSupplierAddress.PermCountry,
                        PermState = mSupplierAddress.PermState,
                        PermCity = mSupplierAddress.PermCity,
                        PermPin = mSupplierAddress.PermPin,
                        PermPhNo = mSupplierAddress.PermPhNo,
                        OfficeAddress = mSupplierAddress.OfficeAddress,
                        OfficeAddressLine1 = mSupplierAddress.OfficeAddressLine1,
                        OfficeAddressLine2 = mSupplierAddress.OfficeAddressLine2,
                        OfficeCountry = mSupplierAddress.OfficeCountry,
                        OfficeState = mSupplierAddress.OfficeState,
                        OfficeCity = mSupplierAddress.OfficeCity,
                        OfficePin = mSupplierAddress.OfficePin,
                        OfficePhNo = mSupplierAddress.OfficePhNo,
                        EMailId = mSupplierAddress.EMailId,
                        IsCreatedBy = "Vishal",
                        CreateDate = DateTime.Now,
                        IsSynchronized = false                        
                    }
                };
                return View(model);
            }            
        }
        [HttpGet]
        // GET: User/MSuppliers/Create
        public async Task<IActionResult> Create()
        {
            var supplierId = await _supplierService.GetSupplierId();
            string supplierCode = await _supplierService.GetSupplierCodeById();           
                
            var model = new Manufacturing_Core.ViewModels.MSupplierViewModel()
            {
                MSupplier=new MSupplier() 
                {
                    PkSupId= (int)supplierId,
                    SupplierCode = supplierCode
                }
            };

            return View(model);
        }

        // POST: User/MSuppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] Manufacturing_Core.ViewModels.MSupplierViewModel mSupplierViewModel)
        {
            if (ModelState.IsValid)
            {
                var model = new Manufacturing_Core.ViewModels.MSupplierViewModel()
                {
                    MSupplier = new MSupplier()
                    {
                        SupplierCode = mSupplierViewModel.MSupplier.SupplierCode == null ? "" : mSupplierViewModel.MSupplier.SupplierCode,
                        SupplierName = mSupplierViewModel.MSupplier.SupplierName == null ? "" : mSupplierViewModel.MSupplier.SupplierName,
                        ShortName = mSupplierViewModel.MSupplier.ShortName == null ? "" : mSupplierViewModel.MSupplier.ShortName,                        
                        LicenceId = mSupplierViewModel.MSupplier.LicenceId == null ? "" : mSupplierViewModel.MSupplier.LicenceId,
                        VATNo = mSupplierViewModel.MSupplier.VATNo == null ? "" : mSupplierViewModel.MSupplier.VATNo,
                        CSTNo = mSupplierViewModel.MSupplier.CSTNo == null ? "" : mSupplierViewModel.MSupplier.CSTNo,
                        TINno = mSupplierViewModel.MSupplier.TINno == null ? "" : mSupplierViewModel.MSupplier.TINno,
                        GSTIn = mSupplierViewModel.MSupplier.GSTIn == null ? "" : mSupplierViewModel.MSupplier.GSTIn,
                        IsCreatedBy =User.Identity.Name,
                        CreatedDate = DateTime.Now,
                        IsUpdatedBy = User.Identity.Name,
                        UpdatedDate = DateTime.Now,
                        IsSynchronized = false                 
                    },
                };
                int supplierId = await _supplierService.SaveSupplierAsync(model);

                if(supplierId>0)
                {

                    var modelAdd = new Manufacturing_Core.ViewModels.MSupplierViewModel()
                    {
                        mAddress = new MAddress()
                        {
                            Name = mSupplierViewModel.mAddress.Name,
                            CurrentAddress = mSupplierViewModel.mAddress.CurrentAddress,
                            CurrentAddressLine1 = mSupplierViewModel.mAddress.CurrentAddressLine1,
                            CurrentAddressLine2 = mSupplierViewModel.mAddress.CurrentAddressLine2,
                            Country = mSupplierViewModel.mAddress.Country,
                            State = mSupplierViewModel.mAddress.State,
                            City = mSupplierViewModel.mAddress.City,
                            Pin = mSupplierViewModel.mAddress.Pin,
                            PhNo = mSupplierViewModel.mAddress.PhNo,
                            PermAddress = mSupplierViewModel.mAddress.PermAddress,
                            PermAddressLine1 = mSupplierViewModel.mAddress.PermAddressLine1,
                            PermAddressLine2 = mSupplierViewModel.mAddress.PermAddressLine2,
                            PermCountry = mSupplierViewModel.mAddress.PermCountry,
                            PermState = mSupplierViewModel.mAddress.PermState,
                            PermCity = mSupplierViewModel.mAddress.PermCity,
                            PermPin = mSupplierViewModel.mAddress.PermPin,
                            PermPhNo = mSupplierViewModel.mAddress.PermPhNo,
                            OfficeAddress = mSupplierViewModel.mAddress.OfficeAddress,
                            OfficeAddressLine1 = mSupplierViewModel.mAddress.OfficeAddressLine1,
                            OfficeAddressLine2 = mSupplierViewModel.mAddress.OfficeAddressLine2,
                            OfficeCountry = mSupplierViewModel.mAddress.OfficeCountry,
                            OfficeState = mSupplierViewModel.mAddress.OfficeState,
                            OfficeCity = mSupplierViewModel.mAddress.OfficeCity,
                            OfficePin = mSupplierViewModel.mAddress.OfficePin,
                            OfficePhNo = mSupplierViewModel.mAddress.OfficePhNo,
                            EMailId = mSupplierViewModel.mAddress.EMailId,
                            IsCreatedBy = User.Identity.Name,
                            CreateDate = DateTime.Now,
                            IsSynchronized = false,
                            FKLedgerNo = 0,
                            FkSupId=supplierId
                        }
                    };
                    var addressId = await _supplierService.SaveSupplierAddressInformationAsync(modelAdd);
                    if (addressId > 0)
                    {
                        TempData["Action"]= "Create";
                        TempData["AlertMessage"]="Supplier created successfully.";
                        return RedirectToAction(nameof(Index));
                    }
                }       
            }
            return View(mSupplierViewModel);
        }
        [HttpGet]
        // GET: User/MSuppliers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mSupplierViewModel = await _supplierService.GetSupplierInfoById(id);
            var mSupplierAddress= await _supplierService.GetSupplierAddressById(id);
            if (mSupplierViewModel == null)
            {
                return NotFound();
            }
            else
            {
                var model = new Manufacturing_Core.ViewModels.MSupplierViewModel()
                {
                    MSupplier = new MSupplier()
                    {
                        PkSupId = mSupplierViewModel.PkSupId,
                        SupplierCode = mSupplierViewModel.SupplierCode == null ? "" : mSupplierViewModel.SupplierCode,
                        SupplierName = mSupplierViewModel.SupplierName == null ? "" : mSupplierViewModel.SupplierName,
                        ShortName = mSupplierViewModel.ShortName == null ? "" : mSupplierViewModel.ShortName,
                        LicenceId = mSupplierViewModel.LicenceId == null ? "" : mSupplierViewModel.LicenceId,
                        VATNo = mSupplierViewModel.VATNo == null ? "" : mSupplierViewModel.VATNo,
                        CSTNo = mSupplierViewModel.CSTNo == null ? "" : mSupplierViewModel.CSTNo,
                        TINno = mSupplierViewModel.TINno == null ? "" : mSupplierViewModel.TINno,
                        GSTIn = mSupplierViewModel.GSTIn == null ? "" : mSupplierViewModel.GSTIn,
                        IsCreatedBy = "Vishal",
                        CreatedDate = DateTime.Now,
                        IsUpdatedBy = "Vishal",
                        UpdatedDate = DateTime.Now,
                        IsSynchronized = false
                    },
                    mAddress = new MAddress()
                    {
                        Name = mSupplierAddress.Name,
                        CurrentAddress = mSupplierAddress.CurrentAddress,
                        CurrentAddressLine1 = mSupplierAddress.CurrentAddressLine1,
                        CurrentAddressLine2 = mSupplierAddress.CurrentAddressLine2,
                        Country = mSupplierAddress.Country,
                        State = mSupplierAddress.State,
                        City = mSupplierAddress.City,
                        Pin = mSupplierAddress.Pin,
                        PhNo = mSupplierAddress.PhNo,
                        PermAddress = mSupplierAddress.PermAddress,
                        PermAddressLine1 = mSupplierAddress.PermAddressLine1,
                        PermAddressLine2 = mSupplierAddress.PermAddressLine2,
                        PermCountry = mSupplierAddress.PermCountry,
                        PermState = mSupplierAddress.PermState,
                        PermCity = mSupplierAddress.PermCity,
                        PermPin = mSupplierAddress.PermPin,
                        PermPhNo = mSupplierAddress.PermPhNo,
                        OfficeAddress = mSupplierAddress.OfficeAddress,
                        OfficeAddressLine1 = mSupplierAddress.OfficeAddressLine1,
                        OfficeAddressLine2 = mSupplierAddress.OfficeAddressLine2,
                        OfficeCountry = mSupplierAddress.OfficeCountry,
                        OfficeState = mSupplierAddress.OfficeState,
                        OfficeCity = mSupplierAddress.OfficeCity,
                        OfficePin = mSupplierAddress.OfficePin,
                        OfficePhNo = mSupplierAddress.OfficePhNo,
                        EMailId = mSupplierAddress.EMailId,
                        IsCreatedBy = "Vishal",
                        CreateDate = DateTime.Now,
                        IsSynchronized = false,
                        FKLedgerNo = 0,
                        FkSupId = id
                    }
                };
                return View(model);
            }
                
        }

        // POST: User/MSuppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind] Manufacturing_Core.ViewModels.MSupplierViewModel mSupplierViewModel)
        {
            if (id != mSupplierViewModel.MSupplier.PkSupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var model = new Manufacturing_Core.ViewModels.MSupplierViewModel()
                    {
                        MSupplier = new MSupplier()
                        {
                            PkSupId=mSupplierViewModel.MSupplier.PkSupId,
                            SupplierCode = mSupplierViewModel.MSupplier.SupplierCode == null ? "" : mSupplierViewModel.MSupplier.SupplierCode,
                            SupplierName = mSupplierViewModel.MSupplier.SupplierName == null ? "" : mSupplierViewModel.MSupplier.SupplierName,
                            ShortName = mSupplierViewModel.MSupplier.ShortName == null ? "" : mSupplierViewModel.MSupplier.ShortName,
                            LicenceId = mSupplierViewModel.MSupplier.LicenceId == null ? "" : mSupplierViewModel.MSupplier.LicenceId,
                            VATNo = mSupplierViewModel.MSupplier.VATNo == null ? "" : mSupplierViewModel.MSupplier.VATNo,
                            CSTNo = mSupplierViewModel.MSupplier.CSTNo == null ? "" : mSupplierViewModel.MSupplier.CSTNo,
                            TINno = mSupplierViewModel.MSupplier.TINno == null ? "" : mSupplierViewModel.MSupplier.TINno,
                            GSTIn = mSupplierViewModel.MSupplier.GSTIn == null ? "" : mSupplierViewModel.MSupplier.GSTIn,
                            IsCreatedBy = "Vishal",
                            CreatedDate = DateTime.Now,
                            IsUpdatedBy = "Vishal",
                            UpdatedDate = DateTime.Now,
                            IsSynchronized = false
                        },
                    };

                    var updateSupplier = await _supplierService.UpdateSupplierdetailsAsync(model);
                    if (updateSupplier > 0)
                    {
                        var ModelAdd = new Manufacturing_Core.ViewModels.MSupplierViewModel()
                        {
                            mAddress = new MAddress()
                            {
                                Name = mSupplierViewModel.mAddress.Name,
                                CurrentAddress = mSupplierViewModel.mAddress.CurrentAddress,
                                CurrentAddressLine1 = mSupplierViewModel.mAddress.CurrentAddressLine1,
                                CurrentAddressLine2 = mSupplierViewModel.mAddress.CurrentAddressLine2,
                                Country = mSupplierViewModel.mAddress.Country,
                                State = mSupplierViewModel.mAddress.State,
                                City = mSupplierViewModel.mAddress.City,
                                Pin = mSupplierViewModel.mAddress.Pin,
                                PhNo = mSupplierViewModel.mAddress.PhNo,
                                PermAddress = mSupplierViewModel.mAddress.PermAddress,
                                PermAddressLine1 = mSupplierViewModel.mAddress.PermAddressLine1,
                                PermAddressLine2 = mSupplierViewModel.mAddress.PermAddressLine2,
                                PermCountry = mSupplierViewModel.mAddress.PermCountry,
                                PermState = mSupplierViewModel.mAddress.PermState,
                                PermCity = mSupplierViewModel.mAddress.PermCity,
                                PermPin = mSupplierViewModel.mAddress.PermPin,
                                PermPhNo = mSupplierViewModel.mAddress.PermPhNo,
                                OfficeAddress = mSupplierViewModel.mAddress.OfficeAddress,
                                OfficeAddressLine1 = mSupplierViewModel.mAddress.OfficeAddressLine1,
                                OfficeAddressLine2 = mSupplierViewModel.mAddress.OfficeAddressLine2,
                                OfficeCountry = mSupplierViewModel.mAddress.OfficeCountry,
                                OfficeState = mSupplierViewModel.mAddress.OfficeState,
                                OfficeCity = mSupplierViewModel.mAddress.OfficeCity,
                                OfficePin = mSupplierViewModel.mAddress.OfficePin,
                                OfficePhNo = mSupplierViewModel.mAddress.OfficePhNo,
                                EMailId = mSupplierViewModel.mAddress.EMailId,
                                IsCreatedBy = "Vishal",
                                CreateDate = DateTime.Now,
                                IsSynchronized = false,
                                FKLedgerNo = 0,
                                FkSupId = id
                            }
                        };

                        var updateAdd = await _supplierService.UpdateSupplierAddressByIdAsync(ModelAdd);

                        if (updateAdd > 0)
                        {
                            TempData["Action"] = "Edit";
                            TempData["AlertMessage"] = "Record Updated Successfully";
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {                    
                }
                
            }
            return View(mSupplierViewModel);
        }
        [HttpGet]
        // GET: User/MSuppliers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mSupplierViewModel = await _supplierService.GetSupplierInfoById(id);
            var mSupplierAddress = await _supplierService.GetSupplierAddressById(id);
            if (mSupplierViewModel == null)
            {
                return NotFound();
            }
            else
            {
                var model = new Manufacturing_Core.ViewModels.MSupplierViewModel()
                {
                    MSupplier = new MSupplier()
                    {
                        PkSupId = mSupplierViewModel.PkSupId,
                        SupplierCode = mSupplierViewModel.SupplierCode == null ? "" : mSupplierViewModel.SupplierCode,
                        SupplierName = mSupplierViewModel.SupplierName == null ? "" : mSupplierViewModel.SupplierName,
                        ShortName = mSupplierViewModel.ShortName == null ? "" : mSupplierViewModel.ShortName,
                        LicenceId = mSupplierViewModel.LicenceId == null ? "" : mSupplierViewModel.LicenceId,
                        VATNo = mSupplierViewModel.VATNo == null ? "" : mSupplierViewModel.VATNo,
                        CSTNo = mSupplierViewModel.CSTNo == null ? "" : mSupplierViewModel.CSTNo,
                        TINno = mSupplierViewModel.TINno == null ? "" : mSupplierViewModel.TINno,
                        GSTIn = mSupplierViewModel.GSTIn == null ? "" : mSupplierViewModel.GSTIn,
                        IsCreatedBy = "Vishal",
                        CreatedDate = DateTime.Now,
                        IsUpdatedBy = "Vishal",
                        UpdatedDate = DateTime.Now,
                        IsSynchronized = false
                    },
                    mAddress = new MAddress()
                    {
                        Name = mSupplierAddress.Name,
                        CurrentAddress = mSupplierAddress.CurrentAddress,
                        CurrentAddressLine1 = mSupplierAddress.CurrentAddressLine1,
                        CurrentAddressLine2 = mSupplierAddress.CurrentAddressLine2,
                        Country = mSupplierAddress.Country,
                        State = mSupplierAddress.State,
                        City = mSupplierAddress.City,
                        Pin = mSupplierAddress.Pin,
                        PhNo = mSupplierAddress.PhNo,
                        PermAddress = mSupplierAddress.PermAddress,
                        PermAddressLine1 = mSupplierAddress.PermAddressLine1,
                        PermAddressLine2 = mSupplierAddress.PermAddressLine2,
                        PermCountry = mSupplierAddress.PermCountry,
                        PermState = mSupplierAddress.PermState,
                        PermCity = mSupplierAddress.PermCity,
                        PermPin = mSupplierAddress.PermPin,
                        PermPhNo = mSupplierAddress.PermPhNo,
                        OfficeAddress = mSupplierAddress.OfficeAddress,
                        OfficeAddressLine1 = mSupplierAddress.OfficeAddressLine1,
                        OfficeAddressLine2 = mSupplierAddress.OfficeAddressLine2,
                        OfficeCountry = mSupplierAddress.OfficeCountry,
                        OfficeState = mSupplierAddress.OfficeState,
                        OfficeCity = mSupplierAddress.OfficeCity,
                        OfficePin = mSupplierAddress.OfficePin,
                        OfficePhNo = mSupplierAddress.OfficePhNo,
                        EMailId = mSupplierAddress.EMailId,
                        IsCreatedBy = "Vishal",
                        CreateDate = DateTime.Now,
                        IsSynchronized = false,
                        FKLedgerNo = 0,
                        FkSupId = id
                    }
                };
                return View(model);
            }
            //return View();
        }

        // POST: User/MSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mSupplier = await _supplierService.DeleteSupplierInformationByIdAsync(id);
            if (mSupplier>0)
            {
                var msuppAddress = await _supplierService.DeleteSuppAddressByIdAsync(id);
                if (msuppAddress > 0)
                {
                    TempData["Action"] = "Delete";
                    TempData["AlertMessage"] = "Supplier Information Deleted SuccessFully";
                    return RedirectToAction(nameof(Index));
                }
            }
            return NotFound();
        }

        private bool MSupplierViewModelExists(int id)
        {
            return false;//_context.mSupplierViewModels.Any(e => e.Id == id);
        }
    }
}
