using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManufacturingERP_Application.Services
{
    public class CategoryService : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> GetCategorySrNo()
        {
            var srno = await _categoryRepository.GetCategorySrNo();
            if (srno > 0)
            {
                return srno;
            }
            return 0;
        }

        public async Task<List<MCategory>> GetCategoryDetails()
        {
            var categoryDetails = await _categoryRepository.GetCategoryDetails();

            if (categoryDetails != null)
            {
                return categoryDetails;
            }

            return null;
        }

        public async Task<string> GetCategoryCodeAsync()
        {
            var CategoryCode = await _categoryRepository.GetCategoryCodeAsync();
            if (CategoryCode is not null)
            {
                return CategoryCode;
            }
            return null;
        }

        public async Task<MCategory> GetCategoryDetailsById(int id)
        {
            var categoryDetails = await _categoryRepository.GetCategoryDetailsById(id);

            if (categoryDetails != null)
            {
                return categoryDetails;
            }

            return null;
        }

        public async Task<List<SelectListItem>> BindDropDownType()
        {
            var TypeList = await _categoryRepository.BindDropDownType();

            if (TypeList != null)
            {
                return TypeList;
            }
            return null;
        }

        public async Task<List<SelectListItem>> BindDropdownCategory()
        {
            var catList = await _categoryRepository.BindDropdownCategory();

            if (catList != null)
            {
                return catList;
            }
            return null;
        }

        public async Task<int> SaveCategoryDetails(MCategoryViewModel Mcategory)
        {
            var categoryDetails = await _categoryRepository.SaveCategoryDetails(Mcategory);

            if (categoryDetails > 0)
            {
                return categoryDetails;
            }
            return 0;
        }

        public async Task<int> UpdateCategoryDetails(MCategoryViewModel Mcategory)
        {
            var categoryDetails = await _categoryRepository.UpdateCategoryDetails(Mcategory);

            if (categoryDetails > 0)
            {
                return categoryDetails;
            }
            return 0;
        }

        public async Task<int> DeleteAddressInfo(int id)
        {
            var categoryDetails = await _categoryRepository.DeleteAddressInfo(id);

            if (categoryDetails > 0)
            {
                return categoryDetails;
            }
            return 0;
        }

        public async Task<string> GetCategoryNameById(int fkCatId)
        {
            var categoryDetails = await _categoryRepository.GetCategoryNameById(fkCatId);

            if (categoryDetails is not null)
            {
                return categoryDetails;
            }
            return null;
        }
    }
}
