using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Infrastructure.Repository
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public MaterialRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int?> GetMaterialId()
        {
            var materialId = await _dbContext.MMetarials.MaxAsync(x =>(int?) x.PkMatId) == null ? 1 : await _dbContext.MMetarials.MaxAsync(x =>(int?) x.PkMatId);
            if (materialId >= 0)
            {
                int id = Convert.ToInt32(materialId) + 1;
                return id;
            }
            return materialId;
        }

        public async Task<string> GetMaterialCodeById()
        {
            var materialId = await _dbContext.MMetarials.MaxAsync(x => (int?)x.PkMatId) == null ? 1 : await _dbContext.MMetarials.MaxAsync(x => (int?)x.PkMatId);
            if (materialId >= 0)
            {
                string id = "MC00"+materialId;
                return id;
            }
            return string.Empty;
        }

        public async Task<int> SaveMaterialasync(MMetarial mMetarial)
        {
            _dbContext.MMetarials.Add(mMetarial);
            var saveMat= await _dbContext.SaveChangesAsync();
            return saveMat;
        }

        public async Task<List<MMetarial>> GetMaterialList()
        {
            var material = await _dbContext.MMetarials.ToListAsync();
            if (material != null)
            {
                return material;
            }
            return null;
        }

        public async Task<MMetarial> GetmaterialByIdAsync(int id)
        {
            var material = await _dbContext.MMetarials.FirstOrDefaultAsync(x => x.PkMatId == id);

            if (material == null)
            {
                return null;
            }
            return material;
        }

        public async Task<int> UpdatematerialAsync(MMetarial material)
        {
            _dbContext.MMetarials.Update(material);
            var upodateMat= await _dbContext.SaveChangesAsync();
            if (upodateMat > 0)
            {
                return upodateMat;
            }
            return 0;
        }

        public async Task<int> DeleteMaterialByIdAsync(MMetarial mMetarial)
        {
            _dbContext.MMetarials.Remove(mMetarial);
            var deleteMat= await _dbContext.SaveChangesAsync();

            if (deleteMat > 0)
            {
                return deleteMat;
            }
            return 0;
        }
    }
}
