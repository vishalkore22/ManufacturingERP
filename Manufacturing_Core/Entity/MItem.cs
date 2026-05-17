using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Hosting;

namespace Manufacturing_Core.Entity
{
    public class MItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PkItemId { get; set; }
        [Required(ErrorMessage ="Required !!!!")]
        [Column(TypeName ="Varchar(10)")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string ItemCode { get; set; }
        [Required(ErrorMessage ="Required !!!!")]
        [Column(TypeName ="Varchar(250)")]
        //[RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string ItemName { get; set; }
        [Column(TypeName ="Varchar(500)")]
        //[RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string ItemDescription { get; set; }
        public int FkCatId { get; set; }
        [ForeignKey("FkCatId")]
        public MCategory? mCategory { get; set; }
        [Column(TypeName ="Varchar(100)")]
        public string? CategoryName { get; set; }
        [Required(ErrorMessage ="Required !!!!")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numeric values are allowed.")]
        public int ItemQty { get; set; }
        [Required(ErrorMessage ="Required !!!!")]
        [Column(TypeName ="decimal(18,2)")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numeric values are allowed.")]
        public Decimal ItemRate { get; set; }
        public string? ItemImageUrl { get; set; }
        [Required(ErrorMessage ="Required !!!!")]
        public double ItemUnit { get; set; }
        public string? Status { get; set; }
        [Required(ErrorMessage ="Required !!!!")]
        [Column(TypeName ="Varchar(20)")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string HSNCODE { get; set; }
        [Required(ErrorMessage = "Required !!!!")]
        [Column(TypeName = "Varchar(20)")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string SACODE { get; set; }
        public DateTime TransDate { get; set; }
        [Column(TypeName = "Varchar(250)")]
        public string? IsCreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "Varchar(250)")]
        public string? IsUpdatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UpdateDate { get; set; }
        public bool IsSynchronized { get; set; }
        //public string FileName { get; set; }
        //public string DownloadLink { get; set; }

        

    }
}
