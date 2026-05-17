using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Manufacturing_Core.Entity
{
    public class TrInventoryTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PkInTransId { get; set; }
        public int FkMatId { get; set; }
        [ForeignKey(nameof(FkMatId))]
        public virtual MMetarial? MMetarial { get; set; }
        public string? MatName { get; set; }
        public string? TransType { get; set; }
        public int FkWarehouseId { get; set; }
        public string? Warehouse { get; set; }
        public decimal? Qty { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? TransDate { get; set; }
        public int LocationId { get; set; }
        public string? Location { get; set; }
        public int? IsCreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? IsUpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsSynchronized { get; set; }
    }
}
