using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Manufacturing_Infrastructure.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public BankRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public async Task<List<MBank>> GetBankAsync()
        {
            var bank = await _applicationDBContext.MBanks.ToListAsync();

            if (bank is not null)
            {
                return bank;
            }
            return null;
        }

        public async Task<MBank> GetBankByIdAsync(int id)
        {
            var bank = await _applicationDBContext.MBanks.FirstOrDefaultAsync(x=>x.PkBankId==id);

            if (bank is not null)
            {
                return bank;
            }
            return null;
        }

        public async Task<int?> GetMBankId()
        {
            var bank = await _applicationDBContext.MBanks.MaxAsync(x =>(int?) x.PkBankId)==null ? 0 :await _applicationDBContext.MBanks.MaxAsync(x => (int?)x.PkBankId);

            if (bank !=null)
            {
                int bankId = Convert.ToInt32(bank) + 1;
                return bankId;
            }
            return 0;
        }

        public async Task<int> AddBankDetails(MBank Mbank)
        {
            _applicationDBContext.MBanks.Add(Mbank);
            int result =await _applicationDBContext.SaveChangesAsync();

            if (result > 0)
            {
                return result;
            }
            return 0;
        }


        public async Task<int> EditBankDetails(MBank Mbank)
        {
            _applicationDBContext.MBanks.Update(Mbank);
            int result = await _applicationDBContext.SaveChangesAsync();

            if (result > 0)
            {
                return result;
            }
            return 0;
        }

        public async Task<int> DeleteBankDetails(int id)
        {
            MBank mBank = new MBank()
            {
                PkBankId = id,
                IsSynchronized = true
            };
            _applicationDBContext.MBanks.Remove(mBank);
            int result = await _applicationDBContext.SaveChangesAsync();

            if (result > 0)
            {
                return result;
            }
            return 0;
        }
    }
}
