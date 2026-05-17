using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Manufacturing_Infrastructure.Repository
{
    public class ItemRepository: IItemRepository
    {
        public readonly ApplicationDBContext _dbContext;
        
        public ItemRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MItem>> GetAllItemList()
        {
            var itemdetails = await (from i in _dbContext.MItems
                                     join c in _dbContext.MCategory
                                     on i.FkCatId equals c.PkCatId
                                     select new MItem
                                     {
                                         PkItemId=i.PkItemId,
                                         ItemCode = i.ItemCode,
                                         CategoryName = i.CategoryName,
                                         ItemName = i.ItemName,
                                         ItemQty = i.ItemQty,
                                         ItemRate = i.ItemRate,
                                         HSNCODE = i.HSNCODE,
                                         SACODE = i.SACODE
                                     }).ToListAsync();

            if (itemdetails != null)
            {
                return itemdetails;
            }

            return null;
        }

        public async Task<MItem> GetItemById(int id)
        {
            var item = await _dbContext.MItems.FirstOrDefaultAsync(x => x.PkItemId == id);

            if (item != null)
            {
                return item;
            }
            return null;
        }

        public async Task<int> SaveItemDetails(MItemViewModel itemList)
        {
            _dbContext.MItems.Add(itemList.mItem);
            var listitem = await _dbContext.SaveChangesAsync();
            if (listitem > 0)
            {
                return listitem;
            }
            return 0;
        }

        public async Task<int> UpdateItemDetails(MItemViewModel itemList)
        {
            _dbContext.MItems.Update(itemList.mItem);
            var listitem = await _dbContext.SaveChangesAsync();
            if (listitem > 0)
            {
                return listitem;
            }
            return 0;
        }

        public async Task<int> DeleteItemDetails(int id)
        {

            var mItem = new MItem()
            {
                PkItemId = id,
                IsSynchronized = true
            };
            _dbContext.MItems.Remove(mItem);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return result;
            }
            return 0;
        }

        public async Task<int> GetItemSerialNo()
        {
            var SrNo = await _dbContext.MItems.MaxAsync(x => (int?)x.PkItemId) == null ? 0 : await _dbContext.MItems.MaxAsync(x => (int)x.PkItemId);
            int SerialNo= SrNo + 1;           

            if (SerialNo>0)
            {
                return SerialNo;
            }
            return 0;
        }

        public async Task<string> GetItemCode()
        {
            var itemcode = await _dbContext.MItems.MaxAsync(x => (int?)x.PkItemId) == null ? 0 : await _dbContext.MItems.MaxAsync(x => (int)x.PkItemId);
            int icode = itemcode + 1;
            string srNumber = "";
            if (icode > 999 && icode < 99)
            {
                srNumber = "IC0" + icode;
                return srNumber;
            }
            else if (icode > 9 && icode < 99)
            {
                srNumber = "IC00" + srNumber;
            }
            else if (icode >= 0 && icode < 9)
            {
                srNumber = "IC000" + icode;
            }

            if (srNumber != null)
            {
                return srNumber;
            }
            return null;
        }
    }
}
 