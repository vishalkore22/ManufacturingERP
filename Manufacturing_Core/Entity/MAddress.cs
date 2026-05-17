using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace Manufacturing_Core.Entity
{
    public class MAddress
    {        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PkAddressId { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [Column(TypeName = "Varchar(100)")]
        public string? Name { get; set; }        
        public bool CurrentAddress { get; set; }
        [Required(ErrorMessage = "Address 1 is required.")]
        [Column(TypeName = "Varchar(200)")]
        public string CurrentAddressLine1 { get; set; }

        [Column(TypeName = "Varchar(200)")]
        public string CurrentAddressLine2 { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [Column(TypeName = "Varchar(50)")]
        public string Country { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [Column(TypeName = "Varchar(50)")]
        public string State { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [Column(TypeName = "Varchar(50)")]
        public string City { get; set; }

        [Required(ErrorMessage = "Pin is required.")]
        [Column(TypeName = "Varchar(6)")]
        public string Pin { get; set; }        
        [Required(ErrorMessage = "Phone number is required.")]
        [Column(TypeName = "Varchar(15)")]
        public string PhNo { get; set; }
        
        public bool PermAddress { get; set; }        
        [Required(ErrorMessage = "Address 1 is required.")]
        [Column(TypeName = "Varchar(200)")]
        public string PermAddressLine1 { get; set; }

        [Column(TypeName = "Varchar(200)")]
        public string PermAddressLine2 { get; set; }
        [Column(TypeName = "Varchar(50)")]
        public string? PermCountry { get; set; }
        [Column(TypeName = "Varchar(50)")]
        public string? PermState { get; set; }
        [Column(TypeName = "Varchar(50)")]
        public string? PermCity { get; set; }
        [Column(TypeName = "Varchar(6)")]
        public string? PermPin { get; set; }
        [Column(TypeName = "Varchar(15)")]
        public string? PermPhNo { get; set; }
        public bool? OfficeAddress { get; set; }

        [Required(ErrorMessage = "Address 1 is required.")]
        [Column(TypeName = "Varchar(200)")]
        public string OfficeAddressLine1 { get; set; }
        
        [Column(TypeName = "Varchar(200)")]
        public string OfficeAddressLine2 { get; set; }
        [Column(TypeName = "Varchar(50)")]
        public string? OfficeCountry { get; set; }
        [Column(TypeName = "Varchar(50)")]
        public string? OfficeState { get; set; }
        [Column(TypeName = "Varchar(50)")]
        public string? OfficeCity { get; set; }
        [Column(TypeName = "Varchar(50)")]
        public string? OfficePin { get; set; }
        [Column(TypeName = "Varchar(50)")]
        public string? OfficePhNo { get; set; }

        [Column(TypeName = "Varchar(100)")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? EMailId { get; set; }        
        [Column(TypeName = "Varchar(250)")]
        public string? IsCreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "Varchar(250)")]
        public string? IsUpdatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UpdateDate { get; set; }
        public bool IsSynchronized { get; set; }
        public int FKLedgerNo { get; set; }
        public int FkSupId { get; set; }
        
    }
}
