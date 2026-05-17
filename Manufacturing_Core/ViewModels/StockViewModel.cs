using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.ViewModels
{
    public class StockViewModel
    {
        public int PkStGoodScrapId { get; set; }
        public string SupplierName { get; set; }
        public string MaterialName { get; set; }
        public string WarehouseName { get; set; }
        public string LocationName { get; set; }
        public decimal Qty { get; set; }
        public DateTime CheckedDate { get; set; }
        public decimal UnitMeasurement { get; set; }
        public string FlagGoodsOrScrap { get; set; }
    }
}
