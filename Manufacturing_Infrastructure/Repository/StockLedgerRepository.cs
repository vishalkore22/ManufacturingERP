using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using ManufacturingERP_Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Infrastructure.Repository
{
    public class StockLedgerRepository : IStockLedgerRepository
    {
        private readonly ApplicationDBContext _context;

        public StockLedgerRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(TrStockLedger ledger)
        {
            _context.TrStockLedgers.Add(ledger);
            return await _context.SaveChangesAsync();
        }
    }
}

