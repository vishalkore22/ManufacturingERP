using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.Entity
{
    public enum TransactionType
    {
        StockIn = 1,
        StockOut = 2,
        Transfer = 3,
        AdjustmentIncrease = 4,
        AdjustmentDecrease = 5,
        Scrap = 6
    }


    public enum StockTransactionType
    {
        Purchase = 1,     // IN (Godown)
        Sale = 2,         // OUT (Shop)
        Transfer = 3,     // Godown → Shop
        Adjustment = 4
    }
}
