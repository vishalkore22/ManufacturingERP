using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using System.Threading.Tasks;
using ManufacturingERP_Application.Services;

namespace ManufacturingERP.Areas.User.Controllers
{
    public class MBanksController : BaseController
    {
        private readonly IBankService _bankService;
        private readonly IAccountTypeService _accountTypeService;

        public MBanksController(IBankService bankService, IAccountTypeService accountTypeService)
        {
            _bankService = bankService;
            _accountTypeService = accountTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var bank = await _bankService.GetBankAsync();
            if (bank is not null)
            {
                return View(bank);
            }
            return View();
        }

        // GET: User/MBanks/Details/5
        [HttpGet, ActionName("Details")]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mBank = await _bankService.GetBankByIdAsync(id);
            var accountTypeId = await _accountTypeService.GetType();
            if (accountTypeId is not null)
            {
                ViewData["FkAccountTypeId"] = accountTypeId;
                return View(mBank);                
            }
            return NotFound();
        }

        // GET: User/MBanks/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var bankId =await _bankService.GetMBankId();
            var model = new MBank
            {
                PkBankId = Convert.ToInt32(bankId),
                
            };
            var accountTypeId = await _accountTypeService.GetType();
            if (accountTypeId is not null)
            {                
                ViewData["FkAccountTypeId"] = accountTypeId;
                return View(model);
            }

            return View(model);
        }

        // POST: User/MBanks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkBankId,BankName,BranchName,IFSCCode,MICRCode,AccountNo,IsCreatedBy,CreateDate,IsUpdatedBy,UpdateDate,IsSynchronized,FkAccountTypeId")] MBank mBank)
        {
            if (ModelState.IsValid)
            {
                var Mbank = new MBank()
                {
                    BankName = mBank.BankName,
                    BranchName = mBank.BranchName,
                    IFSCCode = mBank.IFSCCode,
                    MICRCode = mBank.MICRCode,
                    AccountNo = mBank.AccountNo,
                    FkAccountTypeId=mBank.FkAccountTypeId,
                    IsCreatedBy = "",
                    CreateDate = DateTime.Now,
                    IsSynchronized = false
                };
                var bankDetails =await _bankService.AddBankDetails(Mbank);
                if (bankDetails > 0)
                {
                    TempData["Action"] = "Create";
                    TempData["AlertMessage"] = "Bank Details created SuccessFully.";
                    return RedirectToAction(nameof(Index));
                }                
            }
            var accountTypeId = await _accountTypeService.GetType();
            ViewData["FkAccountTypeId"] = accountTypeId;
            return View(mBank);
        }

        // GET: User/MBanks/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _bankService.GetBankByIdAsync(id);
           
            var accountTypeId = await _accountTypeService.GetType();
            if (accountTypeId is not null)
            {
                ViewData["FkAccountTypeId"] = accountTypeId;
                return View(model);
            }            
            return View();
        }

        // POST: User/MBanks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkBankId,BankName,BranchName,IFSCCode,MICRCode,AccountNo,IsCreatedBy,CreateDate,IsUpdatedBy,UpdateDate,IsSynchronized,FkAccountTypeId")] MBank mBank)
        {
            if (id != mBank.PkBankId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var Mbank = new MBank()
                    {
                        PkBankId=mBank.PkBankId,
                        BankName = mBank.BankName,
                        BranchName = mBank.BranchName,
                        IFSCCode = mBank.IFSCCode,
                        MICRCode = mBank.MICRCode,
                        AccountNo = mBank.AccountNo,
                        FkAccountTypeId = mBank.FkAccountTypeId,
                        IsUpdatedBy = "",
                        UpdateDate = DateTime.Now,
                        IsSynchronized = false
                    };
                    var bankDetails = await _bankService.EditBankDetails(Mbank);

                    if (bankDetails > 0)
                    {
                        TempData["Action"] = "Edit";
                        TempData["AlertMessage"] = "Bank Details updated SuccessFully.";
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MBankExists(mBank.PkBankId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            
            return View(mBank);
        }

        // GET: User/MBanks/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _bankService.GetBankByIdAsync(id);
            
            var accountTypeId = await _accountTypeService.GetType();
            if (accountTypeId is not null)
            {
                ViewData["FkAccountTypeId"] = accountTypeId;
                return View(model);
            }

            return View();
        }

        // POST: User/MBanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bankDetails = await _bankService.DeleteBankDetails(id);
            var accountTypeId = await _accountTypeService.GetType();
            if (accountTypeId is not null)
            {
                ViewData["FkAccountTypeId"] = accountTypeId;                
            }
            if (bankDetails > 0)
            {
                TempData["Action"] = "Delete";
                TempData["AlertMessage"] = "Bank Details deleted SuccessFully.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private bool MBankExists(int id)
        {
            return true;// _context.MBanks.Any(e => e.PkBankId == id);
        }
    }
}
