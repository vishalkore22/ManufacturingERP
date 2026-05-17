using Manufacturing_Core.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Interfaces
{
    public interface IAccountTypeRepository
    {
        Task<List<MAccountType>> GetMAccountType();

        Task<int> GetAccountTypeId();

        Task<MAccountType> GetMAccountType(int id);

        Task<int> SaveAccountType(MAccountType mAccountType);

        Task<int> UpdateAccountTypeAsync(MAccountType mAccountType);

        Task<int> DeleteMAccountTypeAsync(int id);

        Task<List<SelectListItem>> GetType();
    }
}
