using Manufacturing_Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.ViewModels
{
    public class MSupplierViewModel
    {        
        //public int Id { get; set; }
        public MSupplier? MSupplier { get; set; }
        public MAddress? mAddress { get; set; }
        public List<MSupplier>? MSuppliersList { get; set; }
     }
}
