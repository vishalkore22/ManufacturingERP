using Manufacturing_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Interfaces
{
    public interface ISubcategoryService
    {
        Task<List<MSubcategory>> GetAllSubcategory();

        Task<MSubcategory> GetSubcategoryById(int id);

        Task<int> GetSubCategorySrNo();

        Task<string> GetSubCategoryCodeAsync();        

        Task<int> SaveSubCategorydetails(Manufacturing_Core.ViewModels.MSubcategoryViewModel Subcat);

        Task<int> UpdateSubCategorydetails(Manufacturing_Core.ViewModels.MSubcategoryViewModel Subcat);

        Task<int> DeleteSubCategoryDetailsByIdAsync(int id);
    }

}
