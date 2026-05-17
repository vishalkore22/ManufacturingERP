using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Manufacturing_Infrastructure.Repository
{
    public class TypeRepository : ITypeRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public TypeRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<List<MType>> GetAllType()
        {
            var type = await _dbContext.MTypes.ToListAsync();
            if (type != null)
            {
                return type;
            }
            return null;
        }

        public async Task<string> GetTypeCode()
        {
            var typeCode = await _dbContext.MTypes.MaxAsync(x => (int?)x.PkTypeId) == null ? 0 : await _dbContext.MTypes.MaxAsync(x => (int?)x.PkTypeId);
            int Code =Convert.ToInt32(typeCode) +1;
            string TypeCd = "";
            if (Code > 999)
            {
                TypeCd = "TC" + Code;
            }
            else if (Code > 99 && Code < 999)
            {
                TypeCd = "TC00" + Code;
            }
            else if (typeCode > 9 && typeCode < 99)
            {
                TypeCd = "TC000" + Code;
            }
            else if (typeCode >= 0 && typeCode < 9)
            {
                TypeCd = "TC0000" + Code;
            }
            if (TypeCd != null)
            {
                return TypeCd;
            }
            return null;
        }

        public async Task<int> SaveMTypeAsync(MType mType)
        {
            _dbContext.MTypes.Add(mType);
            var result =await _dbContext.SaveChangesAsync();

            if (result > 0)
            {
                return result;
            }
            return 0;
        }

        public async Task<MType> GetTypeByIdAsync(int id)
        {
            var type = await _dbContext.MTypes.FirstOrDefaultAsync(x => x.PkTypeId == id);
            if (type is not null)
            {
                return type;
            }
            return null;
        }

        public async Task<int> UpdateTypeDetailsAsync(MType Mtype)
        {
            _dbContext.MTypes.Update(Mtype);
            var result =await _dbContext.SaveChangesAsync();
            if (result>0)
            {
                return result;                
            }
            return 0;
        }

        public async Task<int> DeleteTypeDetailsAsync(int id)
        {
            MType mtype = new MType()
            {
                PkTypeId = id,
                IsSynchronized = true
            };
            _dbContext.MTypes.Remove(mtype);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return result;
            }
            return 0;
        }

        public async Task<int?> GetTypeIdAsync()
        {
            var typeId = await _dbContext.MTypes.MaxAsync(x => (int?)x.PkTypeId) == null ? 0 : await _dbContext.MTypes.MaxAsync(x => (int?)x.PkTypeId);

            var TypeId = typeId + 1;
            if (TypeId > 0)
            {
                return TypeId;
            }
            return 0;
        }

        public async Task<string> GetTypeNameById(int id)
        {
            var typeName = await (from c in _dbContext.MTypes
                                  where c.PkTypeId == id
                                  select new MType
                                  {
                                      TypeName = c.TypeName
                                  }).FirstOrDefaultAsync();

            if (typeName != null)
            {
                return typeName.ToString();
            }
            return null;
        }

    }
}
