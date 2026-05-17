using Manufacturing_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.ViewModels
{
    public class MCategoryViewModel
    {
        public MCategory mCategory { get; set; }
        public MType? mType { get; set; }

        public List<MCategory>? ListMCategory { get; set; }
    }
}
