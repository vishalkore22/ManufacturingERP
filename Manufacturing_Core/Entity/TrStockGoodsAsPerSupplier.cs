using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.Entity
{
    public class TrStockGoodsAsPerSupplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PkStGoodsId { get; set; }
        public int FkSupId { get; set; }
        public int FkMatId { get; set; }
        public int FkWarehouseId { get; set; }
        public int LocationId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Qty { get; set; }
        public DateTime CheckedDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitMeasurement { get; set; }
        [MaxLength(100)]
        public string? IsCreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        [MaxLength(100)]
        public string? IsUpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsSynchronized { get; set; }
    }
}
