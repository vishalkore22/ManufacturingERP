using Manufacturing_Core.Entity;

namespace ManufacturingERP.Areas.User.Models
{
    public class MSubcategoryViewModel
    {
        public MSubcategory mSubcategory { get; set; }
        public MCategory? mCategory { get; set; }
        public MType? mType { get; set; }
        public List<MSubcategory>? ListMCategory { get; set; }
    }
}
