using Manufacturing_Core.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManufacturingERP_Application.Interfaces
{
    public interface IAccountTypeService
    {
        Task<List<MAccountType>> GetMAccountType();

        Task<MAccountType> GetMAccountType(int id);

        Task<int> GetAccountTypeId();

        Task<int> SaveAccountType(MAccountType mAccountType);

        Task<int> UpdateAccountTypeAsync(MAccountType mAccountType);

        Task<int> DeleteMAccountTypeAsync(int id);

        Task<List<SelectListItem>> GetType();
    }
}
