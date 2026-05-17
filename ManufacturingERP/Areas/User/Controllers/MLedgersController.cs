using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using Manufacturing_Core.ViewModels;

namespace ManufacturingERP.Areas.User.Controllers
{
    public class MLedgersController : BaseController
    {
        private readonly ApplicationDBContext _context;
        private readonly ILedgerService _ledgerService;

        public MLedgersController(ApplicationDBContext context, ILedgerService ledgerService)
        {
            _context = context;
            _ledgerService = ledgerService;
        }

        // GET: User/MLedgers
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ledgerinfo = await _ledgerService.GetLedgerInformation();
            var mledgerInfo = new MLedgerAddressViewModel()
            {
                ListMLedger = ledgerinfo
            };
            return View(mledgerInfo);
        }

        // GET: User/MLedgers/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var mLedger = await _ledgerService.GetLedgerAndAddressInfoAsync(id);
            var mAddress = await _ledgerService.GetAddressInfoAsync(id);
            var model = new MLedgerAddressViewModel()
            {
                mLedgers = new MLedger()
                {
                    PKLedgerNo = mLedger.PKLedgerNo,
                    CompanyNumber = mLedger.CompanyNumber,
                    LedgerUserNo = mLedger.LedgerUserNo,
                    LedgerName = mLedger.LedgerName,
                    OpeningBalance = mLedger.OpeningBalance,
                    ContactPerson = mLedger.ContactPerson,
                    FaxNo = mLedger.FaxNo,
                    CSTNo = mLedger.CSTNo,
                    BSTNo = mLedger.BSTNo,
                    IncomeTaxNo = mLedger.IncomeTaxNo,
                    VATNo = mLedger.VATNo,
                    SaleTaxNo = mLedger.SaleTaxNo,
                    PANNo = mLedger.PANNo,
                    ExciseRegestrationNo = mLedger.ExciseRegestrationNo,
                    ServiceTaxRegNo = mLedger.ServiceTaxRegNo,
                    IsServiceTaxApply = mLedger.IsServiceTaxApply,
                    WebSite = mLedger.WebSite,
                    FkBankId = mLedger.FkBankId,
                    GSTINNo = mLedger.GSTINNo,
                    UINNo = mLedger.UINNo
                },
                mAddresses = new MAddress()
                {
                    Name = mAddress.Name,
                    CurrentAddress = mAddress.CurrentAddress,
                    CurrentAddressLine1 = mAddress.CurrentAddressLine1,
                    CurrentAddressLine2 = mAddress.CurrentAddressLine2,
                    Country = mAddress.Country,
                    State = mAddress.State,
                    City = mAddress.City,
                    Pin = mAddress.Pin,
                    PhNo = mAddress.PhNo,
                    PermAddress = mAddress.PermAddress,
                    PermAddressLine1 = mAddress.PermAddressLine1,
                    PermAddressLine2 = mAddress.PermAddressLine2,
                    PermCountry = mAddress.PermCountry,
                    PermState = mAddress.PermState,
                    PermCity = mAddress.PermCity,
                    PermPin = mAddress.PermPin,
                    PermPhNo = mAddress.PermPhNo,
                    OfficeAddress = mAddress.OfficeAddress,
                    OfficeAddressLine1 = mAddress.OfficeAddressLine1,
                    OfficeAddressLine2 = mAddress.OfficeAddressLine2,
                    OfficeCountry = mAddress.OfficeCountry,
                    OfficeState = mAddress.OfficeState,
                    OfficeCity = mAddress.OfficeCity,
                    OfficePin = mAddress.OfficePin,
                    OfficePhNo = mAddress.OfficePhNo,
                    EMailId = mAddress.EMailId
                }
            };
            if (mLedger == null)
            {
                return NotFound();
            }
            var bankinfo = await _ledgerService.GetBankInfo();
            if (bankinfo is not null)
            {
                ViewData["FkBankId"] = bankinfo;
            }
            if (model != null)
            {
                return View(model);
            }
            return NotFound();
        }

        // GET: User/MLedgers/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var CompanyNo = await _ledgerService.GetCompanyNumber();
            var LedgerUserNo = await _ledgerService.GetLedgerUserNumber();
            var model = new MLedgerAddressViewModel()
            {
                mLedgers = new MLedger()
                {
                    CompanyNumber = CompanyNo,
                    LedgerUserNo = LedgerUserNo
                },
            };
            var bankinfo = await _ledgerService.GetBankInfo();
            if (bankinfo is not null)
            {
                ViewData["FkBankId"] = bankinfo;
            }
            return View(model);
        }

        // POST: User/MLedgers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind]MLedgerAddressViewModel mLedgerAddressViewModel)
        {
            if (ModelState.IsValid)
            {
                var mLedger = new MLedgerAddressViewModel()
                {

                    mLedgers = new MLedger()
                    {
                        CompanyNumber = mLedgerAddressViewModel.mLedgers.CompanyNumber,
                        LedgerUserNo = mLedgerAddressViewModel.mLedgers.LedgerUserNo,
                        LedgerName = mLedgerAddressViewModel.mLedgers.LedgerName,
                        OpeningBalance = mLedgerAddressViewModel.mLedgers.OpeningBalance,
                        ContactPerson = mLedgerAddressViewModel.mLedgers.ContactPerson,
                        FaxNo = mLedgerAddressViewModel.mLedgers.FaxNo,
                        CSTNo = mLedgerAddressViewModel.mLedgers.CSTNo,
                        BSTNo = mLedgerAddressViewModel.mLedgers.BSTNo,
                        IncomeTaxNo = mLedgerAddressViewModel.mLedgers.IncomeTaxNo,
                        VATNo = mLedgerAddressViewModel.mLedgers.VATNo,
                        SaleTaxNo = mLedgerAddressViewModel.mLedgers.SaleTaxNo,
                        PANNo = mLedgerAddressViewModel.mLedgers.PANNo,
                        ExciseRegestrationNo = mLedgerAddressViewModel.mLedgers.ExciseRegestrationNo,
                        ServiceTaxRegNo = mLedgerAddressViewModel.mLedgers.ServiceTaxRegNo,
                        IsServiceTaxApply = mLedgerAddressViewModel.mLedgers.IsServiceTaxApply == true ? mLedgerAddressViewModel.mLedgers.IsServiceTaxApply : mLedgerAddressViewModel.mLedgers.IsServiceTaxApply,
                        WebSite = mLedgerAddressViewModel.mLedgers.WebSite,
                        FkBankId = mLedgerAddressViewModel.mLedgers.FkBankId,
                        GSTINNo = mLedgerAddressViewModel.mLedgers.GSTINNo,
                        UINNo = mLedgerAddressViewModel.mLedgers.UINNo,
                        IsCreatedBy = "",
                        CreateDate = DateTime.Now,
                        IsSynchronized = false
                    },
                };

                var ledgerInformation = await _ledgerService.SaveLedgerInformationAsync(mLedger);
                if (ledgerInformation > 0)
                {
                    var mLedger1 = new MLedgerAddressViewModel()
                    {
                        mAddresses = new MAddress()
                        {
                            Name = mLedgerAddressViewModel.mAddresses.Name,
                            CurrentAddress = mLedgerAddressViewModel.mAddresses.CurrentAddress,
                            CurrentAddressLine1 = mLedgerAddressViewModel.mAddresses.CurrentAddressLine1,
                            CurrentAddressLine2 = mLedgerAddressViewModel.mAddresses.CurrentAddressLine2,
                            Country = mLedgerAddressViewModel.mAddresses.Country,
                            State = mLedgerAddressViewModel.mAddresses.State,
                            City = mLedgerAddressViewModel.mAddresses.City,
                            Pin = mLedgerAddressViewModel.mAddresses.Pin,
                            PhNo = mLedgerAddressViewModel.mAddresses.PhNo,
                            PermAddress = mLedgerAddressViewModel.mAddresses.PermAddress,
                            PermAddressLine1 = mLedgerAddressViewModel.mAddresses.PermAddressLine1,
                            PermAddressLine2 = mLedgerAddressViewModel.mAddresses.PermAddressLine2,
                            PermCountry = mLedgerAddressViewModel.mAddresses.PermCountry,
                            PermState = mLedgerAddressViewModel.mAddresses.PermState,
                            PermCity = mLedgerAddressViewModel.mAddresses.PermCity,
                            PermPin = mLedgerAddressViewModel.mAddresses.PermPin,
                            PermPhNo = mLedgerAddressViewModel.mAddresses.PermPhNo,
                            OfficeAddress = mLedgerAddressViewModel.mAddresses.OfficeAddress,
                            OfficeAddressLine1 = mLedgerAddressViewModel.mAddresses.OfficeAddressLine1,
                            OfficeAddressLine2 = mLedgerAddressViewModel.mAddresses.OfficeAddressLine2,
                            OfficeCountry = mLedgerAddressViewModel.mAddresses.OfficeCountry,
                            OfficeState = mLedgerAddressViewModel.mAddresses.OfficeState,
                            OfficeCity = mLedgerAddressViewModel.mAddresses.OfficeCity,
                            OfficePin = mLedgerAddressViewModel.mAddresses.OfficePin,
                            OfficePhNo = mLedgerAddressViewModel.mAddresses.OfficePhNo,
                            EMailId = mLedgerAddressViewModel.mAddresses.EMailId,
                            IsCreatedBy = "",
                            CreateDate = DateTime.Now,
                            IsSynchronized = false,
                            FKLedgerNo = await _ledgerService.GetMaxPkLedgerNo()
                        }
                    };
                    var addressInformation = await _ledgerService.SaveLedgerAddressInformation(mLedger1.mAddresses);
                    if (addressInformation > 0)
                    {
                        TempData["Action"] = "Create";
                        TempData["AlertMessage"] = "Ledger Information Created successfully.";
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            var CompanyNo = await _ledgerService.GetCompanyNumber();
            var LedgerUserNo = await _ledgerService.GetLedgerUserNumber();
            var model = new MLedgerAddressViewModel()
            {
                mLedgers = new MLedger()
                {
                    CompanyNumber = CompanyNo,
                    LedgerUserNo = LedgerUserNo
                },
            };
            var bankinfo = await _ledgerService.GetBankInfo();
            if (bankinfo is not null)
            {
                ViewData["FkBankId"] = bankinfo;
            }
            return View(model);
        }

        // GET: User/MLedgers/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var mLedger = await _ledgerService.GetLedgerAndAddressInfoAsync(id);
            var mAddress = await _ledgerService.GetAddressInfoAsync(id);
            var model = new MLedgerAddressViewModel()
            {
                mLedgers = new MLedger()
                {
                    PKLedgerNo=mLedger.PKLedgerNo,
                    CompanyNumber = mLedger.CompanyNumber,
                    LedgerUserNo = mLedger.LedgerUserNo,
                    LedgerName = mLedger.LedgerName,
                    OpeningBalance = mLedger.OpeningBalance,
                    ContactPerson = mLedger.ContactPerson,
                    FaxNo = mLedger.FaxNo,
                    CSTNo = mLedger.CSTNo,
                    BSTNo = mLedger.BSTNo,
                    IncomeTaxNo = mLedger.IncomeTaxNo,
                    VATNo = mLedger.VATNo,
                    SaleTaxNo = mLedger.SaleTaxNo,
                    PANNo = mLedger.PANNo,
                    ExciseRegestrationNo = mLedger.ExciseRegestrationNo,
                    ServiceTaxRegNo = mLedger.ServiceTaxRegNo,
                    IsServiceTaxApply = mLedger.IsServiceTaxApply,
                    WebSite = mLedger.WebSite,
                    FkBankId = mLedger.FkBankId,
                    GSTINNo = mLedger.GSTINNo,
                    UINNo = mLedger.UINNo
                },
                mAddresses=new MAddress()
                {
                    Name = mAddress.Name,
                    CurrentAddress = mAddress.CurrentAddress,
                    CurrentAddressLine1 = mAddress.CurrentAddressLine1,
                    CurrentAddressLine2 = mAddress.CurrentAddressLine2,
                    Country = mAddress.Country,
                    State = mAddress.State,
                    City = mAddress.City,
                    Pin = mAddress.Pin,
                    PhNo = mAddress.PhNo,
                    PermAddress = mAddress.PermAddress,
                    PermAddressLine1 = mAddress.PermAddressLine1,
                    PermAddressLine2 = mAddress.PermAddressLine2,
                    PermCountry = mAddress.PermCountry,
                    PermState = mAddress.PermState,
                    PermCity = mAddress.PermCity,
                    PermPin = mAddress.PermPin,
                    PermPhNo = mAddress.PermPhNo,
                    OfficeAddress = mAddress.OfficeAddress,
                    OfficeAddressLine1 = mAddress.OfficeAddressLine1,
                    OfficeAddressLine2 = mAddress.OfficeAddressLine2,
                    OfficeCountry = mAddress.OfficeCountry,
                    OfficeState = mAddress.OfficeState,
                    OfficeCity = mAddress.OfficeCity,
                    OfficePin = mAddress.OfficePin,
                    OfficePhNo = mAddress.OfficePhNo,
                    EMailId = mAddress.EMailId
                }
            };
            if (mLedger == null)
            {
                return NotFound();
            }
            var bankinfo = await _ledgerService.GetBankInfo();
            if (bankinfo is not null)
            {
                ViewData["FkBankId"] = bankinfo;

            }
            if (model != null)
            {
                return View(model);
            }
            return View();
        }

        // POST: User/MLedgers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind] MLedgerAddressViewModel mLedgerAddressViewModel)
        {
            if (id != mLedgerAddressViewModel.mLedgers.PKLedgerNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int mledgerId = mLedgerAddressViewModel.mLedgers.PKLedgerNo;
                    var mLedger = new MLedgerAddressViewModel()
                    {

                        mLedgers = new MLedger()
                        {
                            PKLedgerNo=mLedgerAddressViewModel.mLedgers.PKLedgerNo,
                            CompanyNumber = mLedgerAddressViewModel.mLedgers.CompanyNumber,
                            LedgerUserNo = mLedgerAddressViewModel.mLedgers.LedgerUserNo,
                            LedgerName = mLedgerAddressViewModel.mLedgers.LedgerName,
                            OpeningBalance = mLedgerAddressViewModel.mLedgers.OpeningBalance,
                            ContactPerson = mLedgerAddressViewModel.mLedgers.ContactPerson,
                            FaxNo = mLedgerAddressViewModel.mLedgers.FaxNo,
                            CSTNo = mLedgerAddressViewModel.mLedgers.CSTNo,
                            BSTNo = mLedgerAddressViewModel.mLedgers.BSTNo,
                            IncomeTaxNo = mLedgerAddressViewModel.mLedgers.IncomeTaxNo,
                            VATNo = mLedgerAddressViewModel.mLedgers.VATNo,
                            SaleTaxNo = mLedgerAddressViewModel.mLedgers.SaleTaxNo,
                            PANNo = mLedgerAddressViewModel.mLedgers.PANNo,
                            ExciseRegestrationNo = mLedgerAddressViewModel.mLedgers.ExciseRegestrationNo,
                            ServiceTaxRegNo = mLedgerAddressViewModel.mLedgers.ServiceTaxRegNo,
                            IsServiceTaxApply = mLedgerAddressViewModel.mLedgers.IsServiceTaxApply == true ? mLedgerAddressViewModel.mLedgers.IsServiceTaxApply : mLedgerAddressViewModel.mLedgers.IsServiceTaxApply,
                            WebSite = mLedgerAddressViewModel.mLedgers.WebSite,
                            FkBankId = mLedgerAddressViewModel.mLedgers.FkBankId,
                            GSTINNo = mLedgerAddressViewModel.mLedgers.GSTINNo,
                            UINNo = mLedgerAddressViewModel.mLedgers.UINNo,
                            IsCreatedBy = "",
                            CreateDate = DateTime.Now,
                            IsSynchronized = false
                        },
                    };

                    var ledgerInformation = await _ledgerService.UpdateLedgerInformationAsync(mLedger);
                    if (ledgerInformation > 0)
                    {
                        var mLedger1 = new MLedgerAddressViewModel()
                        {
                            mAddresses = new MAddress()
                            {
                                Name = mLedgerAddressViewModel.mAddresses.Name,
                                CurrentAddress = mLedgerAddressViewModel.mAddresses.CurrentAddress,
                                CurrentAddressLine1 = mLedgerAddressViewModel.mAddresses.CurrentAddressLine1,
                                CurrentAddressLine2 = mLedgerAddressViewModel.mAddresses.CurrentAddressLine2,
                                Country = mLedgerAddressViewModel.mAddresses.Country,
                                State = mLedgerAddressViewModel.mAddresses.State,
                                City = mLedgerAddressViewModel.mAddresses.City,
                                Pin = mLedgerAddressViewModel.mAddresses.Pin,
                                PhNo = mLedgerAddressViewModel.mAddresses.PhNo,
                                PermAddress = mLedgerAddressViewModel.mAddresses.PermAddress,
                                PermAddressLine1 = mLedgerAddressViewModel.mAddresses.PermAddressLine1,
                                PermAddressLine2 = mLedgerAddressViewModel.mAddresses.PermAddressLine2,
                                PermCountry = mLedgerAddressViewModel.mAddresses.PermCountry,
                                PermState = mLedgerAddressViewModel.mAddresses.PermState,
                                PermCity = mLedgerAddressViewModel.mAddresses.PermCity,
                                PermPin = mLedgerAddressViewModel.mAddresses.PermPin,
                                PermPhNo = mLedgerAddressViewModel.mAddresses.PermPhNo,
                                OfficeAddress = mLedgerAddressViewModel.mAddresses.OfficeAddress,
                                OfficeAddressLine1 = mLedgerAddressViewModel.mAddresses.OfficeAddressLine1,
                                OfficeAddressLine2 = mLedgerAddressViewModel.mAddresses.OfficeAddressLine2,
                                OfficeCountry = mLedgerAddressViewModel.mAddresses.OfficeCountry,
                                OfficeState = mLedgerAddressViewModel.mAddresses.OfficeState,
                                OfficeCity = mLedgerAddressViewModel.mAddresses.OfficeCity,
                                OfficePin = mLedgerAddressViewModel.mAddresses.OfficePin,
                                OfficePhNo = mLedgerAddressViewModel.mAddresses.OfficePhNo,
                                EMailId = mLedgerAddressViewModel.mAddresses.EMailId,
                                IsCreatedBy = "",
                                CreateDate = DateTime.Now,
                                IsSynchronized = false,
                                FKLedgerNo = mledgerId
                            }
                        };
                        var addressInformation = await _ledgerService.UpdateLedgerAddressInformation(mLedger1.mAddresses);
                        if (addressInformation > 0)
                        {
                            TempData["Action"] = "Edit";
                            TempData["AlertMessage"] = "Ledger Information Updated successfully.";
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MLedgerExists(mLedgerAddressViewModel.mLedgers.PKLedgerNo))
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
            return View(mLedgerAddressViewModel.mLedgers);
        }

        // GET: User/MLedgers/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var mLedger = await _ledgerService.GetLedgerAndAddressInfoAsync(id);
            var mAddress = await _ledgerService.GetAddressInfoAsync(id);
            var model = new MLedgerAddressViewModel()
            {
                mLedgers = new MLedger()
                {
                    CompanyNumber = mLedger.CompanyNumber,
                    LedgerUserNo = mLedger.LedgerUserNo,
                    LedgerName = mLedger.LedgerName,
                    OpeningBalance = mLedger.OpeningBalance,
                    ContactPerson = mLedger.ContactPerson,
                    FaxNo = mLedger.FaxNo,
                    CSTNo = mLedger.CSTNo,
                    BSTNo = mLedger.BSTNo,
                    IncomeTaxNo = mLedger.IncomeTaxNo,
                    VATNo = mLedger.VATNo,
                    SaleTaxNo = mLedger.SaleTaxNo,
                    PANNo = mLedger.PANNo,
                    ExciseRegestrationNo = mLedger.ExciseRegestrationNo,
                    ServiceTaxRegNo = mLedger.ServiceTaxRegNo,
                    IsServiceTaxApply = mLedger.IsServiceTaxApply,
                    WebSite = mLedger.WebSite,
                    FkBankId = mLedger.FkBankId,
                    GSTINNo = mLedger.GSTINNo,
                    UINNo = mLedger.UINNo
                },
                mAddresses = new MAddress()
                {
                    Name = mAddress.Name,
                    CurrentAddress = mAddress.CurrentAddress,
                    CurrentAddressLine1 = mAddress.CurrentAddressLine1,
                    CurrentAddressLine2 = mAddress.CurrentAddressLine2,
                    Country = mAddress.Country,
                    State = mAddress.State,
                    City = mAddress.City,
                    Pin = mAddress.Pin,
                    PhNo = mAddress.PhNo,
                    PermAddress = mAddress.PermAddress,
                    PermAddressLine1 = mAddress.PermAddressLine1,
                    PermAddressLine2 = mAddress.PermAddressLine2,
                    PermCountry = mAddress.PermCountry,
                    PermState = mAddress.PermState,
                    PermCity = mAddress.PermCity,
                    PermPin = mAddress.PermPin,
                    PermPhNo = mAddress.PermPhNo,
                    OfficeAddress = mAddress.OfficeAddress,
                    OfficeAddressLine1 = mAddress.OfficeAddressLine1,
                    OfficeAddressLine2 = mAddress.OfficeAddressLine2,
                    OfficeCountry = mAddress.OfficeCountry,
                    OfficeState = mAddress.OfficeState,
                    OfficeCity = mAddress.OfficeCity,
                    OfficePin = mAddress.OfficePin,
                    OfficePhNo = mAddress.OfficePhNo,
                    EMailId = mAddress.EMailId
                }
            };
            if (mLedger == null)
            {
                return NotFound();
            }
            var bankinfo = await _ledgerService.GetBankInfo();
            if (bankinfo is not null)
            {
                ViewData["FkBankId"] = bankinfo;
                return View(model);
            }

            return View(mLedger);
        }

        // POST: User/MLedgers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleteLedger = await _ledgerService.DeleteLedgerInfo(id);
            if (deleteLedger > 0)
            {
                var deleteAddress = await _ledgerService.DeleteAddressInfo(id);
                if (deleteAddress>0)
                {
                    TempData["Action"] = "Delete";
                    TempData["AlertMessage"] = "Ledger Information deleted successfully.";
                    return RedirectToAction(nameof(Index));
                }
            }
            return NotFound();            
        }

        private bool MLedgerExists(int id)
        {
            return _context.MLedgers.Any(e => e.PKLedgerNo == id);
        }
    }
}
