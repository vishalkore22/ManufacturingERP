using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManufacturingERP_Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService (IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<List<MItem>> GetAllItemList()
        {
            var item = await _itemRepository.GetAllItemList();
            if (item != null)
            {
                return item;
            }
            return null;
        }

        public async Task<MItem> GetItemById(int id)
        {
            var item = await _itemRepository.GetItemById(id);

            if (item != null)
            {
                return item;
            }
            return null;
        }

        public async Task<int> SaveItemDetails(MItemViewModel itemList)
        {
            var cateList = await _itemRepository.SaveItemDetails(itemList);

            if (cateList > 0)
            {
                return cateList;
            }
            return 0;
        }

        public async Task<int> UpdateItemDetails(MItemViewModel itemList)
        {
            var cateList = await _itemRepository.UpdateItemDetails(itemList);

            if (cateList > 0)
            {
                return cateList;
            }
            return 0;
        }

        public async Task<int> DeleteItemDetails(int id)
        {
            var catdel = await _itemRepository.DeleteItemDetails(id);
            if (catdel > 0)
            {
                return catdel;
            }
            return 0;
        }

        public async Task<int> GetItemSerialNo()
        {
            var SrNo = await _itemRepository.GetItemSerialNo();
            if (SrNo >0)
            {
                return SrNo;
            }
            return 0;
        }

        public async Task<string> GetItemCode()
        {
            var itemcode = await _itemRepository.GetItemCode();
            if (itemcode != null)
            {
                return itemcode;
            }
            return null;
        }
    }
}
