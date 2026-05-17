using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.Entity
{
    public class MBooks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookID {get; set;}
        [Required(ErrorMessage = "Required!!!!")]
        [Column(TypeName ="Varchar(250)")]
        public string Title { get; set; }        
        public int AuthorID { get; set; }
        [ForeignKey("AuthorID")]
        public MAuthors? MAuthor { get; set; }
        public DateTime PublishedDate { get; set; }

      
    }
}
