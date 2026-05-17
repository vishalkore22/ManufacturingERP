using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.Entity
{
    public class TrRequirementCollection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequirementCollectionId { get; set; }

        public int? DepartmentId { get; set; }
        [Column(TypeName="Varchar(100)")]
        public string? DepartmentName { get; set; }

        public int? JobId { get; set; }
        [Column(TypeName ="Varchar(100)")]
        public string? Designation { get; set; }

        public int? NumberOfEmployeesRequired { get; set; }

        public string? SelectionCriteria { get; set; }

        public string? ExperienceRequired { get; set; }

        public string? SkillsRequired { get; set; }
        public string? JobDescription1 { get; set; }
        [Column(TypeName="nvarchar(Max)")]
        public string? JobDescription { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsSynchronized { get; set; }
    }
}
