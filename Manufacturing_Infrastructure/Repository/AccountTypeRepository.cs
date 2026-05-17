using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Manufacturing_Infrastructure.Repository
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public AccountTypeRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public async Task<int> GetAccountTypeId()
        {
            var accountTypeId = await _applicationDBContext.MAccountTypes.MaxAsync(x => (int?)x.AccountTypeId) == null ? 0 : await _applicationDBContext.MAccountTypes.MaxAsync(x => (int?)x.AccountTypeId);
            if (accountTypeId != null)
            {
                int accountTypeId1 = Convert.ToInt32(accountTypeId) + 1;
                return accountTypeId1;
            }
            return 0;
        }

        public async Task<List<MAccountType>> GetMAccountType()
        {
            var accountType = await _applicationDBContext.MAccountTypes.Where(x=>x.IsSynchronized==false).ToListAsync();
            if (accountType is not null)
            {
                return accountType;
            }
            return null;
        }

        public async Task<MAccountType> GetMAccountType(int id)
        {
            var accountType = await _applicationDBContext.MAccountTypes.Where(x => x.PkAccountTypeId == id).FirstOrDefaultAsync();
            if (accountType is not null)
            {
                return accountType;
            }
            return null;
        }

        public async Task<int> SaveAccountType(MAccountType mAccountType)
        {

            _applicationDBContext.MAccountTypes.Add(mAccountType);
            var result =await _applicationDBContext.SaveChangesAsync();

            if (result > 0)
            {
                return result;
            }

            return 0;
        }

        public async Task<int> UpdateAccountTypeAsync(MAccountType mAccountType)
        {
            _applicationDBContext.MAccountTypes.Update(mAccountType);
            var result = await _applicationDBContext.SaveChangesAsync();

            if (result > 0)
            {
                return result;
            }

            return 0;
        }

        public async Task<int> DeleteMAccountTypeAsync(int id)
        {
            var mAccountType = new MAccountType()
            {
                PkAccountTypeId = id,
                IsSynchronized = true
            };

            _applicationDBContext.MAccountTypes.Remove(mAccountType);
            var accountType=await _applicationDBContext.SaveChangesAsync();
            if (accountType > 0)
            {
                return accountType;
            }
            return 0;
        }

        public async Task<List<SelectListItem>> GetType()
        {
            //var accountTypes = new List(_applicationDBContext.MAccountTypes, "AccountTypeId", "AccountType");
            List<SelectListItem> accountTypes = null;
            accountTypes=await _applicationDBContext.MAccountTypes
                          .Select(c => new SelectListItem
                          {
                              Text = c.AccountType,
                              Value = c.PkAccountTypeId.ToString()
                          }).ToListAsync();
            if (accountTypes is not null)
            {
                return accountTypes;
            }
            return null;
        }
    }
}
