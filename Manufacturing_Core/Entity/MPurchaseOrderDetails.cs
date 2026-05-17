using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.Entity
{
    public class MPurchaseOrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PODetailID { get; set; }

        [Required]
        public int PO_ID { get; set; }   // FK → PO_Master

        
        public int MaterialID { get; set; }  // FK → Materials table

        
        [StringLength(50)]
        public string? MaterialCode { get; set; }

        
        [StringLength(200)]
        public string? MaterialName { get; set; }

        
        [StringLength(20)]
        public string? UOM { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Rate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        // ---------- Created Date ----------
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        public MPurchaseOrder? PurchaseOrder { get; set; }


        // ---------- Navigation Properties ----------
        //public MPurchaseOrder? PO_Master { get; set; }
        //public MMetarial? Material { get; set; }
    }
}
