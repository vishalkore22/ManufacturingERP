using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Manufacturing_Infrastructure.Repository
{
    public class SubcategoryRepository: ISubcategoryRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public SubcategoryRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MSubcategory>> GetAllSubcategory()
        {
            var subcat = await (from s in _dbContext.MSubcategory
                                join c in _dbContext.MCategory
                                on s.FkCatId equals c.PkCatId
                                join t in _dbContext.MTypes
                                on s.FkTypeId equals t.PkTypeId
                                select new MSubcategory
                                {
                                    PkSubCatId = s.PkSubCatId,
                                    SubCategoryCode = s.SubCategoryCode,
                                    TypeName = t.TypeName,
                                    CategoryName = c.CategoryName,
                                    SubCategoryName = s.SubCategoryName
                                }).ToListAsync();

            if (subcat != null)
            {
                return subcat;
            }
            return null;
        }

        public async Task<MSubcategory> GetSubcategoryById(int id)
        {
            var subcat = await (from s in _dbContext.MSubcategory
                                join c in _dbContext.MCategory
                                on s.FkCatId equals c.PkCatId
                                join t in _dbContext.MTypes
                                on s.FkTypeId equals t.PkTypeId
                                where s.PkSubCatId==id
                                select new MSubcategory
                                {
                                    PkSubCatId = s.PkSubCatId,
                                    SubCategoryCode = s.SubCategoryCode,
                                    TypeName = t.TypeName,
                                    CategoryName = c.CategoryName,
                                    SubCategoryName = s.SubCategoryName,
                                    SubCategoryDescription=s.SubCategoryDescription
                                }).FirstOrDefaultAsync();

            if (subcat != null)
            {
                return subcat;
            }
            return null;
        }

        public async Task<int> GetSubCategorySrNo()
        {
            var subcatSrNo = await _dbContext.MSubcategory.MaxAsync(x => (int?)x.PkSubCatId) == null ? 0 : await _dbContext.MSubcategory.MaxAsync(x => x.PkSubCatId);

            if (subcatSrNo >= 0)
            {
                return subcatSrNo + 1;
            }
            return 0;
        }

        public async Task<string> GetSubCategoryCodeAsync()
        {
            var subcatSrNo = await _dbContext.MSubcategory.MaxAsync(x => (int?)x.PkSubCatId) == null ? 0 : await _dbContext.MSubcategory.MaxAsync(x => x.PkSubCatId);
            int SCatCode = subcatSrNo + 1;
            string SCategoryCode = "";
            if (SCatCode > 99 && SCatCode < 999)
            {
                SCategoryCode = "SC0" + SCatCode;
                return SCategoryCode;
            }
            else if (SCatCode > 9 && SCatCode < 99)
            {
                SCategoryCode = "SC00" + SCatCode;
                return SCategoryCode;
            }
            else if (SCatCode >= 0 && SCatCode < 9)
            {
                SCategoryCode = "SC000" + SCatCode;
                return SCategoryCode;
            }

            if (SCategoryCode != null)
            {
                return SCategoryCode;
            }
            return null;
        }

        public async Task<int> SaveSubCategorydetails(Manufacturing_Core.ViewModels.MSubcategoryViewModel Subcat)
        {
            _dbContext.MSubcategory.Add(Subcat.mSubcategory);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return result;
            }
            return 0;
        }

        public async Task<int> UpdateSubCategorydetails(Manufacturing_Core.ViewModels.MSubcategoryViewModel Subcat)
        {
            _dbContext.MSubcategory.Update(Subcat.mSubcategory);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return result;
            }
            return 0;
        }

        public async Task<int> DeleteSubCategoryDetailsByIdAsync(int id)
        {
            var subcatDelete = new MSubcategory()
            {
                PkSubCatId = id,
                IsSynchronized = true
            };
            _dbContext.MSubcategory.Remove(subcatDelete);
            var result =await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return result;
            }
            return 0;
        }
    }
}
