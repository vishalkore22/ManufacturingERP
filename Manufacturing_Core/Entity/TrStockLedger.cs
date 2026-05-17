using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.Entity
{
    public class TrStockLedger
    {
        public int StockLedgerId { get; set; }
        public int MaterialId { get; set; }
        public int WarehouseId { get; set; }
        public int LocationId { get; set; }
        public int TransactionType { get; set; }
        public decimal Qty { get; set; }
        public DateTime TransactionDate { get; set; }
        public int? ReferenceId { get; set; }
        public string? CreatedBy { get; set; }

        // 🔗 Navigation Properties
        public virtual MMetarial? Material { get; set; }
        public virtual MWarehouses? Warehouse { get; set; }
        public virtual MLocation? Location { get; set; }
    }
}
