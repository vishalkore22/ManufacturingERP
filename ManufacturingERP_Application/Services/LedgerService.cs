using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Services
{
    public class LedgerService : ILedgerService
    {
        private readonly ILedgerRepository _ledgerRepository;

        public LedgerService(ILedgerRepository ledgerRepository)
        {
            _ledgerRepository = ledgerRepository;
        }

        public async Task<string> GetCompanyNumber()
        {
            var companyNumber = await _ledgerRepository.GetCompanyNumber();
            if (companyNumber is not null)
            {
                return companyNumber;
            }
            return null;
        }

        public async Task<string> GetLedgerUserNumber()
        {
            var LedgerUserNumber = await _ledgerRepository.GetLedgerUserNumber();
            if (LedgerUserNumber is not null)
            {
                return LedgerUserNumber;
            }
            return null;
        }

        public async Task<List<MLedger>> GetLedgerInformation()
        {
            var ledgerInfo = await _ledgerRepository.GetLedgerInformation();
            if (ledgerInfo != null)
            {
                return ledgerInfo;
            }
            return null;
        }

        public async Task<int> SaveLedgerInformationAsync(MLedgerAddressViewModel mLedgerAddressViewModel)
        {
            var ledgerInfo = await _ledgerRepository.SaveLedgerInformationAsync(mLedgerAddressViewModel);
            if (ledgerInfo >0)
            {
                return ledgerInfo;
            }
            return 0;
        }

        public async Task<int> GetMaxPkLedgerNo()
        {
            var pkLedgerNo = await _ledgerRepository.GetMaxPkLedgerNo();
            if (pkLedgerNo > 0)
            {
                return pkLedgerNo;
            }
            return 0;
        }

        public async Task<int> SaveLedgerAddressInformation(MAddress mAddresses)
        {
            var mAddress = await _ledgerRepository.SaveLedgerAddressInformation(mAddresses);

            if (mAddress > 0)
            {
                return mAddress;
            }
            return 0;
        }

        public async Task<List<SelectListItem>> GetBankInfo()
        {
            var bankInfo = await _ledgerRepository.GetBankInfo();

            if (bankInfo is not null)
            {
                return bankInfo;
            }
            return null;
        }

        public async Task<MLedger> GetLedgerAndAddressInfoAsync(int id)
        {
            var mLedgerAddress = await _ledgerRepository.GetLedgerAndAddressInfoAsync(id);
            if (mLedgerAddress != null)
            {
                return mLedgerAddress;
            }
            return null;
        }

        public async Task<MAddress> GetAddressInfoAsync(int id)
        {
            var mAddress = await _ledgerRepository.GetAddressInfoAsync(id);
            if (mAddress is not null)
            {
                return mAddress;
            }
            return null;
        }

        public async Task<int> UpdateLedgerInformationAsync(MLedgerAddressViewModel mLedgerAddressViewModel)
        {
            var mLedger = await _ledgerRepository.UpdateLedgerInformationAsync(mLedgerAddressViewModel);
            if (mLedger > 0)
            {
                return mLedger;
            }
            return 0;
        }

        public async Task<int> UpdateLedgerAddressInformation(MAddress mAddresses)
        {
            var mAddress = await _ledgerRepository.UpdateLedgerAddressInformation(mAddresses);
            if (mAddress > 0)
            {
                return mAddress;
            }
            return 0;
        }

        public async Task<int> DeleteLedgerInfo(int id)
        {
            var deleteLedger = await _ledgerRepository.DeleteLedgerInfo(id);
            if (deleteLedger > 0)
            {
                return deleteLedger;
            }
            return 0;
        }

        public async Task<int> DeleteAddressInfo(int id)
        {
            var deleteAddress = await _ledgerRepository.DeleteAddressInfo(id);
            if (deleteAddress > 0)
            {
                return deleteAddress;
            }
            return 0;
        }
    }
}
