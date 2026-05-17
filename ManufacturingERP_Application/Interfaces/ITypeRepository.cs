using Manufacturing_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Interfaces
{
    public interface ITypeRepository
    {
        Task<List<MType>> GetAllType();

        Task<string> GetTypeCode();

        Task<int> SaveMTypeAsync(MType mType);

        Task<MType> GetTypeByIdAsync(int id);

        Task<int> UpdateTypeDetailsAsync(MType Mtype);

        Task<int> DeleteTypeDetailsAsync(int id);

        Task<int?> GetTypeIdAsync();

        Task<string> GetTypeNameById(int id);

    }
}
