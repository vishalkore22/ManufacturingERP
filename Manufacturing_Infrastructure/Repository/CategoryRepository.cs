using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Manufacturing_Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public CategoryRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> GetCategorySrNo()
        {
            var srno = await _dbContext.MCategory.MaxAsync(x => (int?)x.PkCatId) == null ? 0 : await _dbContext.MCategory.MaxAsync(x => x.PkCatId);

            if (srno >= 0)
            {
                return srno+1;
            }
            return 0;
        }
        public async Task<List<MCategory>> GetCategoryDetails()
        {
            var categoryDetails = await (from c in _dbContext.MCategory
                                         join t in _dbContext.MTypes
                                         on c.FkTypeId equals t.PkTypeId
                                         select new MCategory
                                         {
                                             PkCatId = c.PkCatId,
                                             CategoryCode = c.CategoryCode,
                                             TypeName = t.TypeName,
                                             CategoryName = c.CategoryName
                                         }).ToListAsync();
            if (categoryDetails != null)
            {
                return categoryDetails;
            }
            return null;
        }

        public async Task<MCategory> GetCategoryDetailsById(int id)
        {
            var categoryDetails = await (from c in _dbContext.MCategory                                        
                                         join t in _dbContext.MTypes
                                         on c.FkTypeId equals t.PkTypeId
                                         where c.PkCatId==id
                                         select new MCategory
                                         {
                                             PkCatId = c.PkCatId,
                                             CategoryCode = c.CategoryCode,
                                             TypeName = t.TypeName,
                                             CategoryName = c.CategoryName,
                                             CategoryDescription=c.CategoryDescription
                                         }).FirstOrDefaultAsync();
            if (categoryDetails != null)
            {
                return categoryDetails;
            }
            return null;
        }

        public async Task<List<SelectListItem>> BindDropDownType()
        {
            var typeList= await _dbContext.MTypes
                            .Select(c => new SelectListItem
                            {
                                Text = c.TypeName,
                                Value = c.PkTypeId.ToString()
                            }).ToListAsync();
            if (typeList is not null)
            {
                return typeList;
            }
            return null;
        }

        public async Task<List<SelectListItem>> BindDropdownCategory()
        {
            var catList = await _dbContext.MCategory
                             .Select(c => new SelectListItem
                             {
                                 Text = c.CategoryName,
                                 Value = c.PkCatId.ToString()
                             }).ToListAsync();
            if (catList is not null)
            {
                return catList;
            }
            return null;
        }

        public async Task<int> SaveCategoryDetails(MCategoryViewModel Mcategory)
        {
            _dbContext.MCategory.Add(Mcategory.mCategory);
            var categoryresult = await _dbContext.SaveChangesAsync();

            if (categoryresult > 0)
            {
                return categoryresult;
            }
            return 0;
        }


        public async Task<int> UpdateCategoryDetails(MCategoryViewModel Mcategory)
        {
            _dbContext.MCategory.Update(Mcategory.mCategory);
            var categoryresult = await _dbContext.SaveChangesAsync();

            if (categoryresult > 0)
            {
                return categoryresult;
            }
            return 0;
        }

        public async Task<int> DeleteAddressInfo(int id)
        {
            var mCategory = new MCategoryViewModel()
            {
                mCategory = new MCategory()
                {
                    PkCatId = id,
                    IsSynchronized = true
                }
            };

            _dbContext.MCategory.Remove(mCategory.mCategory);
            var result=await _dbContext.SaveChangesAsync();
            if (result >0)
            {
                return result;
            }
            return 0;
        }

        public async Task<string> GetCategoryNameById(int fkCatId)
        {
            var CatName = await _dbContext.MCategory.Where(x => x.PkCatId == fkCatId).Select(x => x.CategoryName).FirstOrDefaultAsync();

            if (CatName != null)
            {
                return CatName.ToString();
            }
            return null;
        }

        public async Task<string> GetCategoryCodeAsync()
        {
            var CCode = await _dbContext.MCategory.MaxAsync(x => (int?)x.PkCatId) == null ? 0 : await _dbContext.MCategory.MaxAsync(x => x.PkCatId);
            int CatCode = CCode + 1;
            string CategoryCode = "";
            if (CatCode > 99 && CatCode < 999)
            {
                CategoryCode = "CC0" + CatCode;
                return CategoryCode;
            }
            else if (CatCode > 9 && CatCode < 99)
            {
                CategoryCode = "CC00" + CatCode;
                return CategoryCode;
            }
            else if (CatCode >=0 && CatCode < 9)
            {
                CategoryCode = "CC000" + CatCode;
                return CategoryCode;
            }

            if (CategoryCode != null)
            {
                return CategoryCode;
            }
            return null;
        }
    }    
}
