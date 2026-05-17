using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.Entity
{
    public class MAuthors
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorID { get; set; }
        [Required(ErrorMessage ="Required !!!.")]
        [Column(TypeName ="varchar(150)")]
        public string Name { get; set; }
        [Column(TypeName ="Varchar(1000)")]
        public string Bio { get; set; }
    }
}
