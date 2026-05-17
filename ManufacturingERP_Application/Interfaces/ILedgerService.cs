using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManufacturingERP_Application.Interfaces
{
    public interface ILedgerService
    {
        Task<string> GetCompanyNumber();

        Task<string> GetLedgerUserNumber();

        Task<List<MLedger>> GetLedgerInformation();

        Task<int> SaveLedgerInformationAsync(MLedgerAddressViewModel mLedgerAddressViewModel);

        Task<int> GetMaxPkLedgerNo();

        Task<int> SaveLedgerAddressInformation(MAddress mAddresses);

        Task<List<SelectListItem>> GetBankInfo();

        Task<MLedger> GetLedgerAndAddressInfoAsync(int id);

        Task<MAddress> GetAddressInfoAsync(int id);

        Task<int> UpdateLedgerInformationAsync(MLedgerAddressViewModel mLedgerAddressViewModel);

        Task<int> UpdateLedgerAddressInformation(MAddress mAddresses);

        Task<int> DeleteLedgerInfo(int id);

        Task<int> DeleteAddressInfo(int id);




    }
}
