using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.Entity
{
    public class MType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PkTypeId { get; set; }
        [Required(ErrorMessage = "Required ....!")]
        [Column(TypeName = ("Varchar(50)"))]
        public string TypeCode { get; set; }
        [Required(ErrorMessage = "Required ....!")]
        [Column(TypeName = ("Varchar(150)"))]
        public string? TypeName { get; set; }
        
        [Column(TypeName = ("Varchar(50)"))]
        public string? TypeDescription { get; set; }
        public DateTime TransDate { get; set; }
        [Column(TypeName = ("Varchar(150)"))]
        public string? IsCreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = ("Varchar(150)"))]
        public string? IsUpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsSynchronized { get; set; }
        public ICollection<MCategory>? Category { get; set; }
        public ICollection<MSubcategory>? Subcategories { get; set; }
        public ICollection<MItem>? Item { get; set; }
    }
}
