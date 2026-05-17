using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.Entity
{
    public class MCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PkCatId { get; set; }
        [Required(ErrorMessage ="Required !!!")]
        [Column(TypeName="Varchar(100)")]
        public string CategoryCode { get; set; }
        public int FkTypeId { get; set; }
        [ForeignKey("FkTypeId")]
        public MType? MType { get; set; }
        public string? TypeName { get; set; }
        [Required(ErrorMessage ="Required !!!")]
        [Column(TypeName ="Varchar(100)")]
        public string CategoryName { get; set; }
        [Column(TypeName = "Varchar(1000)")]
        public string CategoryDescription { get; set; }
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

        public ICollection<MSubcategory>? Subcategories { get; set; }
    }
}
