using Manufacturing_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Interfaces
{
    public interface IBankRepository 
    {
        Task<List<MBank>> GetBankAsync();

        Task<MBank> GetBankByIdAsync(int id);

        Task<int?> GetMBankId();

        Task<int> AddBankDetails(MBank Mbank);

        Task<int> EditBankDetails(MBank Mbank);

        Task<int> DeleteBankDetails(int id);
    }
}
