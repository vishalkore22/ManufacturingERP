using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.Entity
{
    public class TrStockGoodsORScrap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PkStGoodScrapId { get; set; }
        public int FkMatId { get; set; }
        public int FkWarehouseId { get; set; }
        public int LocationId { get; set; }
        public decimal Qty { get; set; }
        public DateTime CheckedDate { get; set; }
        public decimal UnitMeasurement { get; set; }

        // 1 = Goods, 2 = Scrap
        public int FlagGoodsOrScrap { get; set; }
        public string? IsCreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? IsUpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsSynchronized { get; set; }
    }
}
