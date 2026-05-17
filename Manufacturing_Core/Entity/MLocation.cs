using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manufacturing_Core.Entity
{
    public class MLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }
        public int WarehouseId { get; set; }
        [ForeignKey("WarehouseId")]
        public virtual MWarehouses? Warehouse { get; set; }
        public string LocationName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        // 🔗 Navigation Properties        
        public virtual ICollection<TrInventory>? Inventories { get; set; }
        public virtual ICollection<TrStockLedger>? StockLedgers { get; set; }
        public virtual ICollection<TrCurrentStock>? CurrentStocks { get; set; }
    }

}
