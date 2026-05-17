using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ManufacturingERP.Areas.User.Controllers
{
    public class MAccountTypesController : BaseController
    {
        private readonly IAccountTypeService _accountTypeService;

        public MAccountTypesController(IAccountTypeService accountTypeService)
        {
            _accountTypeService = accountTypeService;
        }

        public async Task<IActionResult> Search(string searchBy, string search)
        {
            return View();
        }
        // GET: User/MAccountTypes
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var accountType =await _accountTypeService.GetMAccountType();
            return View(accountType);
        }

        // GET: User/MAccountTypes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mAccountType = await _accountTypeService.GetMAccountType(id);
            if (mAccountType == null)
            {
                return NotFound();
            }

            return View(mAccountType);
        }

        // GET: User/MAccountTypes/Create
        public async Task<IActionResult> Create()
        {
            var accountId = await _accountTypeService.GetAccountTypeId();
            var model = new MAccountType
            {
                AccountTypeId = accountId
            };
            return View(model);
        }

        // POST: User/MAccountTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkAccountTypeId,AccountTypeId,AccountType,IsCreatedBy,CreateDate,IsUpdatedBy,UpdateDate,IsSynchronized,FkBankId")] MAccountType mAccountType)
        {
            if (ModelState.IsValid)
            {
                var mAccountType1 = new MAccountType()
                {
                    AccountTypeId = mAccountType.AccountTypeId,
                    AccountType = mAccountType.AccountType,
                    IsCreatedBy = "",
                    CreateDate = DateTime.Now,
                    IsSynchronized=false
                };
                var accountType = await _accountTypeService.SaveAccountType(mAccountType1);
                if (accountType > 0)
                {
                    TempData["Action"] = "Create";
                    TempData["AlertMessage"] = "Account Type created SuccessFully.";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(mAccountType);
        }

        // GET: User/MAccountTypes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mAccountType = await _accountTypeService.GetMAccountType(id);
            if (mAccountType == null)
            {
                return NotFound();
            }
            return View(mAccountType);
        }

        // POST: User/MAccountTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkAccountTypeId,AccountTypeId,AccountType,IsCreatedBy,CreateDate,IsUpdatedBy,UpdateDate,IsSynchronized,FkBankId")] MAccountType mAccountType)
        {
            if (id != mAccountType.PkAccountTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var mAccountType1 = new MAccountType()
                    {
                        PkAccountTypeId=mAccountType.PkAccountTypeId,
                        AccountTypeId = mAccountType.AccountTypeId,
                        AccountType = mAccountType.AccountType,
                        IsUpdatedBy = "",
                        UpdateDate = DateTime.Now,
                        IsSynchronized=false
                    };
                    var maccountType = await _accountTypeService.UpdateAccountTypeAsync(mAccountType1);
                    if (maccountType > 0)
                    {
                        TempData["Action"] = "Edit";
                        TempData["AlertMessage"] = "Account Type Updated Successfully.";
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await MAccountTypeExists(mAccountType.PkAccountTypeId)==true)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }                
            }
            return View(mAccountType);
        }

        // GET: User/MAccountTypes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mAccountType = await _accountTypeService.GetMAccountType(id);
            if (mAccountType == null)
            {
                return NotFound();
            }

            return View(mAccountType);
        }

        // POST: User/MAccountTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mAccountType = await _accountTypeService.DeleteMAccountTypeAsync(id);
            if (mAccountType >0)
            {
                TempData["Action"] = "Delete";
                TempData["AlertMessage"] = "Account Type deleted Successfully.";
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        private async Task<bool> MAccountTypeExists(int id)
        {
            var accountType= await _accountTypeService.GetMAccountType(id);
            if (accountType is not null)
            {
                return true;
            }
            return false;
        }
    }
}
