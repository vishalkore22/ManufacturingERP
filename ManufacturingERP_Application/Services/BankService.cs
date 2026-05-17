using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
namespace ManufacturingERP_Application.Services
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;

        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public async Task<List<MBank>> GetBankAsync()
        {
            var bank = await _bankRepository.GetBankAsync();
            if (bank is not null)
            {
                return bank;
            }
            return null;
        }

        public async Task<MBank> GetBankByIdAsync(int id)
        {
            var bank = await _bankRepository.GetBankByIdAsync(id);
            if (bank is not null)
            {
                return bank;
            }
            return null;
        }

        public async Task<int?> GetMBankId()
        {
            var bankId = await _bankRepository.GetMBankId();
            if (bankId > 0)
            {
                return bankId;
            }
            return 0;
        }

        public async Task<int> AddBankDetails(MBank Mbank)
        {
            var bankdetails = await _bankRepository.AddBankDetails(Mbank);
            if (bankdetails > 0)
            {
                return bankdetails;
            }
            return 0;
        }

        public async Task<int> EditBankDetails(MBank Mbank)
        {
            var bankdetails = await _bankRepository.EditBankDetails(Mbank);
            if (bankdetails > 0)
            {
                return bankdetails;
            }
            return 0;
        }

        public async Task<int> DeleteBankDetails(int id)
        {
            var bankdetails = await _bankRepository.DeleteBankDetails(id);
            if (bankdetails > 0)
            {
                return bankdetails;
            }
            return 0;
        }
    }
}
