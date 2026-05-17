using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manufacturing_Core.ViewModels
{
    public class TrInventoryViewModel
    {
        //public TrCurrentStock TrCurrentStock { get; set; }
        //public TrStockLedger TrStockLedger { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int WarehouseId { get; set; }
        public int LocationId { get; set; }
        public int? TransactionType { get; set; }
        public decimal? Quantity { get; set; }
        public List<SelectListItem>? Materials { get; set; }
        public List<SelectListItem>? Warehouses { get; set; }
        public List<SelectListItem>? Locations { get; set; }
    }
}
