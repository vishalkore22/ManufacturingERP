using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.Entity
{
    public class TrInventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransId { get; set; }
        public int MaterialId { get; set; }
        public int WarehouseId { get; set; }
        public int LocationId { get; set; }
        public int TransactionType { get; set; }  // Enum recommended
        public decimal Quantity { get; set; }
        public int? UnitId { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Amount => Rate.HasValue ? Quantity * Rate.Value : null;
        public DateTime TransactionDate { get; set; }
        public int? ReferenceId { get; set; }
        public string? ReferenceType { get; set; }
        public string? Remarks { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsSynchronized { get; set; }

        // 🔗 Navigation Properties (Optional but Recommended)
        public virtual MMetarial? Material { get; set; }
        public virtual MWarehouses? Warehouse { get; set; }
        public virtual MLocation? Location { get; set; }
    }
}
