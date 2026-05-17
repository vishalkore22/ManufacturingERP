using Manufacturing_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.ViewModels
{
    public class MLedgerAddressViewModel
    {
        public MLedger mLedgers { get; set; }

        public MAddress mAddresses { get; set; }   

        public List<MLedger>? ListMLedger { get; set; }
    }
}
