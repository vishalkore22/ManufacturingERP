using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.Entity
{
    public class PurchaseQuotation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string QuotationNumber { get; set; }

        public DateTime QuotationDate { get; set; }

        public Guid SupplierId { get; set; }

        public string SupplierName { get; set; }

        public string SupplierGSTIN { get; set; }

        public string CompanyGSTIN { get; set; }

        public string PlaceOfSupply { get; set; }   // State Name

        public bool IsInterState { get; set; }      // true = IGST लागू, false = CGST+SGST

        public decimal TotalAmount { get; set; }    // Before tax

        public decimal TotalDiscount { get; set; }

        public decimal TotalTaxableAmount { get; set; }

        public decimal TotalCGST { get; set; }

        public decimal TotalSGST { get; set; }

        public decimal TotalIGST { get; set; }

        public decimal NetAmount { get; set; }

        public string Remarks { get; set; }

        public bool IsApproved { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public string ApprovedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; }

        // Navigation
        public List<PurchaseQuotationDetail> Details { get; set; }
    }
}
