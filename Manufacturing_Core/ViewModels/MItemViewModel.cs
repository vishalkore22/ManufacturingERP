using Manufacturing_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Core.ViewModels
{
    public class MItemViewModel
    {
        public MItem mItem { get; set; }
        public MType? mType { get; set; }
        public List<MItem>? ListItems { get; set; }
        //public List<MItemDetails>? MItemList { get; set; }
        //public MItemDetails? mItemDtls { get; set; }
    }
}
