using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Services
{
    public class StockLedgerService : IStockLedgerService
    {
        private readonly IStockLedgerRepository _stockLedgerRepository;

        public StockLedgerService(IStockLedgerRepository stockLedgerRepository)
        {
            _stockLedgerRepository = stockLedgerRepository;
        }        
    }
}
