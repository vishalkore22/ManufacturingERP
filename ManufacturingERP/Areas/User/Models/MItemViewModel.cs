using Manufacturing_Core.Entity;

namespace ManufacturingERP.Areas.User.Models
{
    public class MItemViewModel
    {
        public MItem mItem { get; set; }
        public MType? mType { get; set; }
        public List<MItem>? ListItems { get; set; }
    }
}
