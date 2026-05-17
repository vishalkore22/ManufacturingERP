using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Interfaces
{
    public interface IItemService
    {
        Task<List<MItem>> GetAllItemList();

        Task<MItem> GetItemById(int id);       

        Task<int> SaveItemDetails(MItemViewModel itemList);

        Task<int> UpdateItemDetails(MItemViewModel itemList);

        Task<int> DeleteItemDetails(int id);

        Task<int> GetItemSerialNo();

        Task<string> GetItemCode();
    }
}
