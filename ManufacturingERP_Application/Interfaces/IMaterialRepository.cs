using Manufacturing_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Interfaces
{
    public interface IMaterialRepository
    {
        Task<List<MMetarial>> GetMaterialList();
        Task<int?> GetMaterialId();

        Task<string> GetMaterialCodeById();

        Task<int> SaveMaterialasync(MMetarial mMetarial);

        Task<MMetarial> GetmaterialByIdAsync(int id);

        Task<int> UpdatematerialAsync(MMetarial material);

        Task<int> DeleteMaterialByIdAsync(MMetarial mMetarial);
    }
}
