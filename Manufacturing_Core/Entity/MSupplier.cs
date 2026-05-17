using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.Entity
{
    public class MSupplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PkSupId { get; set; }
        [Column(TypeName ="Varchar(25)")]
        public string? SupplierCode { get; set; }
        [Required(ErrorMessage ="Supplier Name is Required!!!")]
        [Column(TypeName ="varchar(250)")]
        public string SupplierName { get; set; }
        [Column(TypeName ="varchar(100)")]
        public string ShortName { get; set; }
        //[Required(ErrorMessage = "MobileNo is Required!!!")]
        //[RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Mobile number must be exactly 10 digits.")]
        //public string MobileNo { get; set; }
        //[EmailAddress(ErrorMessage = "Invalid email address.")]
        //public string? EmailID { get; set; }
        //[Column(TypeName = "varchar(100)")]
        //public string? LAddress { get; set; }
        //[Column(TypeName = "varchar(25)")]
        //public string LCity { get; set; }
        //[Column(TypeName = "varchar(25)")]
        //public string LTehsil { get; set; }
        //[Column(TypeName = "varchar(25)")]
        //public string LDistrict { get; set; }
        //[Required(ErrorMessage = "Pincode is required.")]
        //[RegularExpression(@"^\d{6}$", ErrorMessage = "Pincode must be exactly 6 digits.")]
        //public string LPincode { get; set; }
        //[Column(TypeName = "varchar(25)")]
        //public string LPhoneNo { get; set; }
        //[Column(TypeName = "varchar(100)")]
        //public string PAddress { get; set; }
        //[Column(TypeName = "varchar(25)")]
        //public string PCity { get; set; }
        //[Column(TypeName = "varchar(25)")]
        //public string PTehsil { get; set; }
        //[Column(TypeName = "varchar(25)")]
        //public string PDistrict { get; set; }
        //[Required(ErrorMessage = "Pincode is required.")]
        //[RegularExpression(@"^\d{6}$", ErrorMessage = "Pincode must be exactly 6 digits.")]
        //public string Ppincode { get; set; }

        //public int FkAddressId { get; set; }
        //[ForeignKey("FkAddressId")]
        ////public MAddress? mAddress { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string? LicenceId { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string? VATNo { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string? CSTNo { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string? TINno { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string? GSTIn { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string? IsCreatedBy { get; set; }        
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string? IsUpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsSynchronized { get; set; }
    }
}
