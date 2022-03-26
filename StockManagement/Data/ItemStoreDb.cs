using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockManagement.Models;
using StockManagement.ViewModel;


namespace StockManagement.Data
{
    
    public class ItemStoreDb
    {
        private readonly StockDbContext _context;
        private readonly ItemDb _itemDb;
        private readonly ImageDb _imageDb;
        public ItemStoreDb(StockDbContext context, ItemDb itemDb, ImageDb imageDb)
        {
            _itemDb = itemDb;
            _context = context;
            _imageDb = imageDb;
        }

        public List<ItemStoreVM> GetItemByStoreIdAndCategoryId(int storeId, int categoryId)
        {
            List<ItemStoreVM> itemStoreVMs = (from itm in _context.Items
                                              join cs in _context.ItemStores
                                              on itm.Id equals cs.ItemId
                                              where cs.StoreId == storeId && itm.CayegoryId == categoryId
                                              select new ItemStoreVM
                                              {
                                                  ItemId = itm.Id,
                                                  StoreId = storeId,
                                                  ItemName = itm.Name,
                                                  CategoryId = categoryId,
                                              }
                                                            ).ToList();
            return itemStoreVMs;
        }

        public List<ItemStoreVM> GetItemImageByItemId(List<ItemStoreVM> itemStoreVMs)
        {
            foreach (ItemStoreVM isVM in itemStoreVMs)
            {
                List<Image> images =
                    (
                        from img in _context.Images
                        where img.ItemId == isVM.ItemId
                        select new Image
                        {
                            Id = img.Id,
                            ImageUrl = img.ImageUrl,
                            ItemId = isVM.ItemId,

                        }
                    ).ToList();
                isVM.ImageUrls = images;
            }
            return itemStoreVMs;
        }

        public ItemStore Add(ItemStore itemStore)
        {
            _context.ItemStores.Add(itemStore);
            _context.SaveChanges();
            return itemStore;
        }

        public ItemStore GetByItemIdAndStoreId(int itemId, int storeId)
        {
            return _context.ItemStores.FirstOrDefault(x => x.ItemId == itemId && x.StoreId == storeId);
        }

        public void DeleteItemFromStore(int itemId, int storeId)
        {
            ItemStore itemStore = GetByItemIdAndStoreId(itemId, storeId);
            if (itemStore != null)
            {
                _context.ItemStores.Remove(itemStore);
                _context.SaveChanges();
            }
        }
    }
}
