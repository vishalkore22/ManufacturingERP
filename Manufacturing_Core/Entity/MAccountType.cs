using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Manufacturing_Core.Entity
{
    public class MAccountType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PkAccountTypeId { get; set; }
        [Required(ErrorMessage = "Account Type Id is required.")]
        public int AccountTypeId { get; set; }

        [Required(ErrorMessage = "Account Type is required.")]
        [Column(TypeName = "Varchar(150)")]
        public string AccountType { get; set; }

        [Column(TypeName = "Varchar(250)")]
        public string? IsCreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "Varchar(250)")]
        public string? IsUpdatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UpdateDate { get; set; }
        public bool IsSynchronized { get; set; }
        public int? FkBankId { get; set; }
        [ForeignKey("FkBankId")]
        public ICollection<MBank>? MBanks { get; set; }
    }
}
