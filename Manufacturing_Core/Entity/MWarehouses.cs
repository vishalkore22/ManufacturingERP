using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manufacturing_Core.Entity
{
    public class MWarehouses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PkWarehouseId { get; set; }
        public string? WarehouseCode { get; set; }
        public string? WarehouseName { get; set; }
        public int? LocationId { get; set; }
        public string? LocationName { get; set; }
        public int? Capacity { get; set; }
        public string? Status { get; set; }
        public string? IsCreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? IsUpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsSynchronized { get; set; }
        public virtual ICollection<MWarehouses> Warehouse { get; set; }
    }
}
