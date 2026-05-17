using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ManufacturingERP_Application.Services
{
    public class AccountTypeService: IAccountTypeService
    {
        private readonly IAccountTypeRepository _accountTypeRepository;
        public AccountTypeService(IAccountTypeRepository accountTypeRepository)
        {
            _accountTypeRepository = accountTypeRepository;
        }

        public async Task<int> GetAccountTypeId()
        {
            var accountTypeId = await _accountTypeRepository.GetAccountTypeId();
            if (accountTypeId != null)
            {
                return accountTypeId;
            }
            return 0;
        }
        public async Task<List<MAccountType>> GetMAccountType()
        {
            var accountType =await _accountTypeRepository.GetMAccountType();
            if (accountType is not null)
            {
                return accountType;
            }
            return null;
        }

        public async Task<MAccountType> GetMAccountType(int id)
        {
            var accountType = await _accountTypeRepository.GetMAccountType(id);
            if (accountType is not null)
            {
                return accountType;
            }
            return null;
        }

        public async Task<int> SaveAccountType(MAccountType mAccountType)
        {
            var accountType = await _accountTypeRepository.SaveAccountType(mAccountType);
            if (accountType>0)
            {
                return accountType;
            }
            return 0;
        }

        public async Task<int> UpdateAccountTypeAsync(MAccountType mAccountType)
        {
            var accountType = await _accountTypeRepository.UpdateAccountTypeAsync(mAccountType);
            if (accountType > 0)
            {
                return accountType;
            }
            return 0;
        }

        public async Task<int> DeleteMAccountTypeAsync(int id)
        {
            var accountType = await _accountTypeRepository.DeleteMAccountTypeAsync(id);
            if (accountType > 0)
            {
                return accountType;
            }
            return 0;
        }

        public async Task<List<SelectListItem>> GetType()
        {
            var accountType = await _accountTypeRepository.GetType();
            if (accountType != null)
            {
                return accountType;
            }
            return null;
        }
    }
}
