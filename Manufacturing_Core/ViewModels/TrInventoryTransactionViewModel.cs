using Manufacturing_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.ViewModels
{
    public class TrInventoryTransactionViewModel
    {
        public TrInventoryTransaction TrInventoryTransaction { get; set; }

        public MMetarial mMetarial { get; set; }
    }
}
