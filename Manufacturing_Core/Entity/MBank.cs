using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Manufacturing_Core.Entity
{
    public class MBank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PkBankId { get; set; }

        [Required(ErrorMessage = "Bank Name is required.")]
        [Column(TypeName = "Varchar(250)")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Branch Name is required.")]
        [Column(TypeName = "Varchar(100)")]
        public string BranchName { get; set; }
        [Required(ErrorMessage = "IFSC Code is required.")]
        [Column(TypeName = "Varchar(25)")]
        public string IFSCCode { get; set; }

        [Required(ErrorMessage = "MICR Code is required.")]
        [Column(TypeName = "Varchar(25)")]
        public string MICRCode { get; set; }

        [Required(ErrorMessage = "Account No is required.")]
        [Column(TypeName = "Varchar(25)")]
        public string AccountNo { get; set; }
        [Column(TypeName = "Varchar(250)")]
        public string? IsCreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "Varchar(250)")]
        public string? IsUpdatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UpdateDate { get; set; }
        public bool IsSynchronized { get; set; }
        public int FkAccountTypeId { get; set; }
        [ForeignKey("FkAccountTypeId")]
        public MAccountType? MAccountTypes { get; set; }
        
    }
}
