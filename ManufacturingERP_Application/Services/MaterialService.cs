using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<List<MMetarial>> GetMaterialList()
        {
            var material = await _materialRepository.GetMaterialList();
            if (material == null)
            {
                return null;
            }
            return material;
        }

        public async Task<int?> GetMaterialId()
        {
            var materialId = await _materialRepository.GetMaterialId();

            if (materialId == null)
            {
                return 0;
            }
            return materialId;
        }

        public async Task<string> GetMaterialCodeById()
        {
            var materialCode = await _materialRepository.GetMaterialCodeById();
            if (materialCode == null)
            {
                return string.Empty;
            }
            return materialCode;
        }

        public async Task<int> SaveMaterialasync(MMetarial mMetarial)
        {
            var saveMat = await _materialRepository.SaveMaterialasync(mMetarial);
            if (saveMat == null)
            {
                return 0;
            }
            return saveMat;
        }

        public async Task<int> UpdatematerialAsync(MMetarial material)
        {
            var updateMat = await _materialRepository.UpdatematerialAsync(material);
            if (updateMat > 0)
            {
                return updateMat;
            }
            return 0;
        }

        public async Task<int> DeleteMaterialByIdAsync(MMetarial mMetarial)
        {
            var deleteMat = await _materialRepository.DeleteMaterialByIdAsync(mMetarial);

            if (deleteMat == null)
            {
                return 0;
            }
            return deleteMat;
        }

        public async Task<MMetarial> GetmaterialByIdAsync(int id)
        {
            var material = await _materialRepository.GetmaterialByIdAsync(id);

            if (material == null)
            {
                return null;
            }

            return material;
        }
    }
}
