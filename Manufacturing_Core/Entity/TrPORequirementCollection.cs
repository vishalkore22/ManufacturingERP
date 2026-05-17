using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.Entity
{
    public class TrPORequirementCollection
    {
            //Primary Key
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int PkRequirementID { get; set; }

            // Reference Numbers
            [Required(ErrorMessage ="Requirement Number is Mandatory.")]
            [Column(TypeName ="Varchar(15)")]
            public string RequirementNumber { get; set; }   // e.g., RQ-2025-001
            [DataType(DataType.Date)]
            public DateTime? TransDate { get; set; }
            [Required(ErrorMessage = "Work Order Number is Mandatory.")]
            [Column(TypeName = "Varchar(15)")]
            public string WorkOrderNumber { get; set; }     // Link to production WO
            [Required(ErrorMessage ="BOM Number is Mandatory.")]
            [Column(TypeName ="Varchar(10)")]
            public string BOMNumber { get; set; }           // If requirement generated from BOM

            // Material Information
            public int MaterialID { get; set; }                 // FK to Item / Material master
            public string? MaterialCode { get; set; }
            public string? MatName { get; set; }
            public string? MatDescription { get; set; }

            // Quantity Information
            public decimal RequiredQty { get; set; }
            public string? Unit { get; set; }                // Kg, Nos, Mtr etc.
            public int StockAvailableQty { get; set; }
            public int PurchaseQty { get; set; }        // Required – StockAvailable

            // Requirement Type
            public string RequirementSource { get; set; }   // (Production, Stores, Manual)
            [DataType(DataType.Date)]
            public DateTime? RequiredDate { get; set; }      // For planning & urgency
            public string Priority { get; set; }            // (Low/Medium/High/Urgent)

            // Status Information
            public string? RequirementStatus { get; set; }   // (Pending / Approved / PO Created)
            public string ApprovedBy { get; set; }
            [DataType(DataType.Date)]
            public DateTime? ApprovedDate { get; set; }

            // Audit Fields
            public string? CreatedBy { get; set; }
            public DateTime? CreatedDate { get; set; }
            public string? UpdatedBy { get; set; }
            public DateTime? UpdatedDate { get; set; }

            // Synchronization for Mobile/Cloud ERP usage
            public bool IsSynchronized { get; set; }
            //public List<SelectListItem>? MaterialListItem { get; set; }
    }
}
