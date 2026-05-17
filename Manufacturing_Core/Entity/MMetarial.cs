using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.Entity
{
    public class MMetarial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PkMatId { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string? MatCode { get; set; }
        [Required(ErrorMessage ="Required !!!!")]
        [Column(TypeName ="varchar(150)")]
        public string? MatName { get; set; }

        public string? MatDescription { get; set; }

        public decimal? MatQty { get; set; }

        public decimal? MatRate { get; set; }

        public int? MatUnit { get; set; }

        public string? HSNCode { get; set; }

        public string? SACode { get; set; }

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
