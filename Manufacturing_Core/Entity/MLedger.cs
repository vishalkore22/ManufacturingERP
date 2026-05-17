using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Manufacturing_Core.Entity
{
    public class MLedger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PKLedgerNo { get; set; }
        //[Required(ErrorMessage ="Company Number is Required.")]
        [Column(TypeName ="Varchar(20)")]
        public string CompanyNumber { get; set; }
        //[Required(ErrorMessage = "Ledger User No Is Required.")]
        [Column(TypeName = "Varchar(20)")]
        public string LedgerUserNo { get; set; }
        [Required(ErrorMessage = "Ledger Name Is Required.")]
        [Column(TypeName = "Varchar(250)")]
        public string LedgerName { get; set; }
        [Column(TypeName = "Varchar(250)")]
        public decimal? OpeningBalance { get; set; }
        [Column(TypeName = "Varchar(500)")]
        public string? ContactPerson { get; set; }
        [Column(TypeName = "Varchar(20)")]
        public string? FaxNo { get; set; }
        [Column(TypeName = "Varchar(50)")]
        public string? CSTNo { get; set; }
        [Column(TypeName = "Varchar(20)")]
        public string? BSTNo { get; set; }
        [Column(TypeName = "Varchar(20)")]
        public string? IncomeTaxNo { get; set; }
        [Column(TypeName = "Varchar(20)")]
        public string? VATNo { get; set; }
        [Column(TypeName = "Varchar(20)")]
        public string? SaleTaxNo { get; set; }        
        [Column(TypeName = "Varchar(10)")]
        [StringLength(10)]
        public string? PANNo { get; set; }
        [Column(TypeName = "Varchar(15)")]
        public string? ExciseRegestrationNo { get; set; }
        [Column(TypeName = "Varchar(15)")]
        public string? ServiceTaxRegNo { get; set; }
        public bool IsServiceTaxApply { get; set; }
        [Column(TypeName = "Varchar(20)")]
        public string WebSite { get; set; }
        [Column(TypeName = "Varchar(250)")]
        public string? IsCreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "Varchar(250)")]
        public string? IsUpdatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UpdateDate { get; set; }
        public bool IsSynchronized { get; set; }
        public int FkBankId { get; set; }
        [ForeignKey("FkBankId")]
        public MBank? MBanks { get; set; }
        [Column(TypeName = "Varchar(15)")]
        public string GSTINNo { get; set; }
        [Column(TypeName = "Varchar(15)")]
        public string UINNo { get; set; }
    }
}
