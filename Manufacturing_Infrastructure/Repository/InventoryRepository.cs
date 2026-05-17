using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Infrastructure.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public InventoryRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public async Task<List<TrInventoryViewModel>> GetInventoryViewModel()
        {
            var inventory = await _applicationDBContext.TrInventoryViewModels.ToListAsync();

            return inventory;
        }

        public async Task<int> AddAsync(TrInventoryViewModel inventory)
        {
            _applicationDBContext.TrInventoryViewModels.Add(inventory);
            var result = await _applicationDBContext.SaveChangesAsync();
            return result;
        }
    }
}
