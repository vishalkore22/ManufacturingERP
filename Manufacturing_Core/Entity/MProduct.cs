using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.Entity
{
    public class MProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PkProdId { get; set; }
        [Required(ErrorMessage ="Required !!!")]
        [Column(TypeName ="Varchar(50)")]
        public string ProdCode { get; set; }
        [Required(ErrorMessage ="Required!!!!")]
        [Column(TypeName ="varchar(100)")]
        public string ProdName { get; set; }
        [Column(TypeName ="varchar(100)")]
        public string? ProdDescription { get; set; }
        public decimal ProdQty { get; set; }
        public decimal ProductRate { get; set; }
        public byte[]? ProdImage { get; set; }
        [Column(TypeName = "Varchar(250)")]
        public string? IsCreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "Varchar(250)")]
        public string? IsUpdatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UpdateDate { get; set; }
        public bool IsSynchronized { get; set; }

    }
}
