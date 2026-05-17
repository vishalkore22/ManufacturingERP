using Manufacturing_Core.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManufacturingERP.Areas.User.Models
{
    public class MSupplierViewModel
    {       
        public MSupplier? MSupplier { get; set; }
        public MAddress? MAddress { get; set; }
    }
}
