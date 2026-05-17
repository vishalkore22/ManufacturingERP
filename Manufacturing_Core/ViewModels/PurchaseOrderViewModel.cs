using Manufacturing_Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.ViewModels
{
    
    public class PurchaseOrderViewModel
    {
        //[Key]
        //public int id { get; set; }
        public MPurchaseOrder? MPurchaseOrder { get; set; }

        public MPurchaseOrderDetails? mPurchaseOrderDetails { get; set; }        

        public List<MPurchaseOrderDetails> MPurchaseOrderDetails { get; set; }        

        public List<MPurchaseOrder>? ListMPurchaseOrders { get; set; }

        public List<MMetarial>? MMetarials { get; set; }

        public MMetarial? MMetarial { get; set; }

        public MSupplier? MSupplier { get; set; }

    }
}
