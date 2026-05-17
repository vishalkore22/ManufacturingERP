using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Services
{
    public class SubcategoryService : ISubcategoryService
    {
        private readonly ISubcategoryRepository _subcategoryRepository;

        public SubcategoryService(ISubcategoryRepository subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
        }

        public async Task<List<MSubcategory>> GetAllSubcategory()
        {
            var subcat = await _subcategoryRepository.GetAllSubcategory();
            if (subcat != null)
            {
                return subcat;
            }
            return null;
        }

        public async Task<MSubcategory> GetSubcategoryById(int id)
        {
            var subcat = await _subcategoryRepository.GetSubcategoryById(id);

            if (subcat != null)
            {
                return subcat;
            }
            return null;
        }

        public async Task<int> GetSubCategorySrNo()
        {
            var subcat = await _subcategoryRepository.GetSubCategorySrNo();
            if (subcat > 0)
            {
                return subcat;
            }
            return 0;
        }

        public async Task<string> GetSubCategoryCodeAsync()
        {
            var subcatcode = await _subcategoryRepository.GetSubCategoryCodeAsync();

            if (subcatcode != null)
            {
                return subcatcode;
            }
            return null;
        }

        public async Task<int> SaveSubCategorydetails(Manufacturing_Core.ViewModels.MSubcategoryViewModel Subcat)
        {
            var result = await _subcategoryRepository.SaveSubCategorydetails(Subcat);
            if (result > 0)
            {
                return result;
            }
            return 0;
        }

        public async Task<int> UpdateSubCategorydetails(Manufacturing_Core.ViewModels.MSubcategoryViewModel Subcat) 
        {
            var result = await _subcategoryRepository.UpdateSubCategorydetails(Subcat);
            if (result > 0)
            {
                return result;
            }
            return 0;
        }

        public async Task<int> DeleteSubCategoryDetailsByIdAsync(int id)
        {
            var result = await _subcategoryRepository.DeleteSubCategoryDetailsByIdAsync(id);
            if (result > 0)
            {
                return result;
            }
            return 0;
        }
    }
}
