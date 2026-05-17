using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manufacturing_Core.Entity
{
    public class MPurchaseOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PO_ID { get; set; }
        [Required(ErrorMessage ="PO Number is Mandatory...")]
        [Column(TypeName ="Varchar(13)")]
        public string PO_Number { get; set; }  //-- e.g., PO2025-001
        [DataType(DataType.Date)]
        public DateTime? PO_Date { get; set; }
        [Required(ErrorMessage ="Supplier is Mandatory...")]
        public int Supplier_ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Delivery_Date { get; set; }
        [Column(TypeName ="Varchar(100)")]
        public string? Payment_Terms { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountAmount { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal GSTPercentage { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal GSTAmount { get; set; }

        // ---------- Computed Columns ----------

        
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        

        
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetAmount { get; set; }
        [Column(TypeName ="Varchar(500)")]
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }
        [Column(TypeName ="Varchar(10)")]
        public string Currency { get; set; }
        [Column(TypeName ="Varchar(25)")]
        public string PO_Status { get; set; }  //-- Pending/Approved/Closed/Cancelled
        public string? Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public string? Approved_By { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Approved_Date { get; set; }
        public bool? IsSyncronized { get; set; }

        public ICollection<MPurchaseOrderDetails>? PurchaseOrderDetails { get; set; }
    }
}
