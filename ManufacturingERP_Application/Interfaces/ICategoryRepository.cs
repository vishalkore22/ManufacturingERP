using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<MCategory>> GetCategoryDetails();

        Task<int> GetCategorySrNo();

        Task<string> GetCategoryCodeAsync();

        Task<MCategory> GetCategoryDetailsById(int id);

        Task<List<SelectListItem>> BindDropDownType();

        Task<List<SelectListItem>> BindDropdownCategory();
        Task<int> SaveCategoryDetails(MCategoryViewModel Mcategory);

        Task<int> UpdateCategoryDetails(MCategoryViewModel Mcategory);

        Task<int> DeleteAddressInfo(int id);

        Task<string> GetCategoryNameById(int fkCatId);
    }
}
