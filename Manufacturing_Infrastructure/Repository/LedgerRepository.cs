using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Infrastructure.Repository
{
    public class LedgerRepository : ILedgerRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public LedgerRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public async Task<string> GetCompanyNumber()
        {
            var companyNo = await _applicationDBContext.MLedgers.MaxAsync(x => (int?)x.PKLedgerNo) == null ? 0 : await _applicationDBContext.MLedgers.MaxAsync(x => (int?)x.PKLedgerNo);

            if (companyNo is not null)
            {
                string CompanyNumber = "";
                if (companyNo > 99 && companyNo < 999)
                {
                    string number = "000"+Convert.ToString(companyNo + 1);
                    CompanyNumber = DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + number;
                }
                else if (companyNo > 10 && companyNo < 99)
                {
                    string number = "00"+Convert.ToString(companyNo + 1);
                    CompanyNumber = DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + number;
                }
                else if ((companyNo > 0 || companyNo==0) && companyNo < 9)
                {
                    string number = "0"+Convert.ToString(companyNo + 1);
                    CompanyNumber = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + number;
                }
                return CompanyNumber;
            }
            return null;
        }

        public async Task<string> GetLedgerUserNumber()
        {
            var LedgerUserNo = await _applicationDBContext.MLedgers.MaxAsync(x => (int?)x.PKLedgerNo) == null ? 0 : await _applicationDBContext.MLedgers.MaxAsync(x => (int?)x.PKLedgerNo);

            if (LedgerUserNo is not null)
            {
                string LedgerUserNUmber = "";
                if (LedgerUserNo > 99 && LedgerUserNo < 999)
                {
                    string number = "L000"+Convert.ToString(LedgerUserNo + 1);
                    LedgerUserNUmber = number+DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year;
                }
                else if (LedgerUserNo > 10 && LedgerUserNo < 99)
                {
                    string number = "L00" + Convert.ToString(LedgerUserNo + 1);
                    LedgerUserNUmber = number+DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year;
                }
                else if ((LedgerUserNo > 0 || LedgerUserNo == 0) && LedgerUserNo < 9)
                {
                    string number = "L0" + Convert.ToString(LedgerUserNo + 1);
                    LedgerUserNUmber = number + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year;
                }
                return LedgerUserNUmber;
            }
            return null;
        }

        public async Task<List<MLedger>> GetLedgerInformation()
        {
            var ledgerInfo = await (from C in _applicationDBContext.MLedgers
                                    select new MLedger
                                    {
                                        PKLedgerNo=C.PKLedgerNo,
                                        LedgerUserNo = C.LedgerUserNo,
                                        LedgerName = C.LedgerName,
                                        OpeningBalance = C.OpeningBalance,
                                        ContactPerson = C.ContactPerson,
                                        PANNo = C.PANNo
                                    }).ToListAsync();

            if (ledgerInfo is not null)
            {
                return ledgerInfo;
            }
            return null;
        }

        public async Task<int> SaveLedgerInformationAsync(MLedgerAddressViewModel mLedgerAddressViewModel)
        {
            _applicationDBContext.MLedgers.Add(mLedgerAddressViewModel.mLedgers);
            var ledgerinfo=await _applicationDBContext.SaveChangesAsync();

            if (ledgerinfo > 0)
            {
                return ledgerinfo;
            }
            return 0;
        }

        public async Task<int> GetMaxPkLedgerNo()
        {
            var pkLedgerNo = await _applicationDBContext.MLedgers.MaxAsync(x => x.PKLedgerNo);

            if (pkLedgerNo > 0)
            {
                return pkLedgerNo; 
            }
            return 0;
        }

        public async Task<int> SaveLedgerAddressInformation(MAddress mAddresses)
        {
            _applicationDBContext.MAddresses.Add(mAddresses);
            var result = await _applicationDBContext.SaveChangesAsync();
            if (result > 0)
            {
                return result;
            }
            return 0;
        }

        public async Task<List<SelectListItem>> GetBankInfo()
        {
            var bankInfo = await _applicationDBContext.MBanks
                            .Select(c => new SelectListItem
                            {
                                Text = c.BankName,
                                Value = c.PkBankId.ToString()
                            }).ToListAsync();
            if (bankInfo is not null)
            {
                return bankInfo;
            }
            return null;
        }

        public async Task<MLedger> GetLedgerAndAddressInfoAsync(int id)
        {

            var mLedgerAddress = await _applicationDBContext.MLedgers.Where(x=>x.PKLedgerNo==id).FirstOrDefaultAsync();
                                    

            if (mLedgerAddress !=null)
            {
                return mLedgerAddress;
            }
            return null;
        }

        public async Task<MAddress> GetAddressInfoAsync(int id)
        {
            var mAddress = await _applicationDBContext.MAddresses.Where(x => x.FKLedgerNo == id).FirstOrDefaultAsync();

            if (mAddress != null)
            {
                return mAddress;
            }
            return null;
        }

        public async Task<int> UpdateLedgerInformationAsync(MLedgerAddressViewModel mLedgerAddressViewModel)
        {
            _applicationDBContext.MLedgers.Update(mLedgerAddressViewModel.mLedgers);
            int result =await _applicationDBContext.SaveChangesAsync();
            if (result > 0)
            {
                return result;
            }
            return 0;
        }

        public async Task<int> UpdateLedgerAddressInformation(MAddress mAddresses)
        {
            _applicationDBContext.MAddresses.Update(mAddresses);
            int result = await _applicationDBContext.SaveChangesAsync();
            if (result > 0)
            {
                return result;
            }
            return 0;
        }

        public async Task<int> DeleteLedgerInfo(int id)
        {
            var mLedger = new MLedger()
            {
                PKLedgerNo = id
            };
            _applicationDBContext.MLedgers.Remove(mLedger);
            int result =await _applicationDBContext.SaveChangesAsync();
            if (result > 0)
            {
                return result;
            }
            return 0;
        }

        public async Task<int> DeleteAddressInfo(int id)
        {
            var mAddress = new MAddress()
            {
                FKLedgerNo = id
            };
            _applicationDBContext.MAddresses.Remove(mAddress);
            int result = await _applicationDBContext.SaveChangesAsync();
            if (result > 0)
            {
                return result;
            }
            return 0;
        }
    }
}
