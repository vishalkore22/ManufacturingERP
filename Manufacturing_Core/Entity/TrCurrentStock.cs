using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.Entity
{
    public class TrCurrentStock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MaterialId { get; set; }
        [ForeignKey("MaterialId")]
        public int WarehouseId { get; set; }
        [ForeignKey("WarehouseId")]
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public decimal Qty { get; set; }
        // 🔗 Navigation Properties
        public virtual MMetarial? Material { get; set; }
        public virtual MWarehouses? Warehouse { get; set; }
        public virtual MLocation? Location { get; set; }
    }
}
