using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Manufacturing_Infrastructure.Repository
{
    public class CurrentStockRepository : ICurrentStockRepository
    {
        private readonly ApplicationDBContext _Context;

        public CurrentStockRepository(ApplicationDBContext applicationDBContext)
        {
            _Context = applicationDBContext;
        }

        public async Task<int> UpdateCurrentStock(TrInventoryViewModel trInventoryViewModel)
        {
            var stock = await _Context.TrCurrentStocks.FirstOrDefaultAsync(x =>
            x.MaterialId == trInventoryViewModel.MaterialId &&
            x.WarehouseId == trInventoryViewModel.WarehouseId &&
            x.LocationId == trInventoryViewModel.LocationId);

            if (stock == null)
            {
                stock = new TrCurrentStock
                {
                    MaterialId = trInventoryViewModel.MaterialId,
                    WarehouseId = trInventoryViewModel.WarehouseId,
                    LocationId = trInventoryViewModel.LocationId,
                    Qty = 0
                };

                _Context.TrCurrentStocks.Add(stock);
            }

            // IN / OUT Logic
            if (trInventoryViewModel.TransactionType == Convert.ToInt32(StockTransactionType.Purchase) ||
                trInventoryViewModel.TransactionType == Convert.ToInt32(StockTransactionType.Transfer))
            {
                stock.Qty += Convert.ToDecimal(trInventoryViewModel.Quantity);

                if (stock != null)
                {
                    var quantity = new TrCurrentStock()
                    {
                        Qty = stock.Qty
                    };

                    _Context.TrCurrentStocks.Update(quantity);
                    int result = await _Context.SaveChangesAsync();
                    return result;
                }
                else
                {
                    _Context.TrCurrentStocks.Add(stock);
                    int result=await _Context.SaveChangesAsync();
                    return result;
                }
            }
            else if (trInventoryViewModel.TransactionType == Convert.ToInt32(StockTransactionType.Sale))
            {
                if (stock.Qty < trInventoryViewModel.Quantity)
                    throw new Exception("Insufficient Stock!");

                stock.Qty -= Convert.ToDecimal(trInventoryViewModel.Quantity);

                _Context.TrCurrentStocks.Update(stock);
                var result = await _Context.SaveChangesAsync();
                return result;
            }            
            return 0;
        }
    }
}
