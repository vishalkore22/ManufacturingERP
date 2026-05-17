using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.Entity
{
    public class MSubcategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PkSubCatId { get; set; }
        public string SubCategoryCode { get; set; }
        public int FkTypeId { get; set; }
        [ForeignKey("FkTypeId")]
        public MType? MType { get; set; }
        public string? TypeName { get; set; }
        public int FkCatId { get; set; }
        [ForeignKey("FkCatId")]
        public MCategory? MCategory { get; set; }
        public string? CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryDescription { get; set; }
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

    }
}
