using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockManagement.ViewModel;
using StockManagement.Data;
using StockManagement.Models;

namespace StockManagement.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ItemDb _itemDb;
        private readonly ItemStoreDb _itemStoreDb;

        public ItemsController(ItemDb itemDb, ItemStoreDb itemStoreDb)
        {
            _itemDb = itemDb;
            _itemStoreDb = itemStoreDb;
        }
        public IActionResult Index([FromQuery] int storeId, [FromQuery] int categoryId)
        {
            List<ItemStoreVM> itemStoreVMList = _itemStoreDb.GetItemByStoreIdAndCategoryId(storeId, categoryId);
            itemStoreVMList = _itemStoreDb.GetItemImageByItemId(itemStoreVMList);
            return View(itemStoreVMList);
            
        }

        public IActionResult ShowItemsList([FromRoute] int id)
        {
            List<Item> itemsList = _itemDb.GetByCategoryId(id);

            return View(itemsList);
        }

        public IActionResult AddItem()
        {
            Item Item = new Item();
            return View(Item);
        }

        [HttpPost]
        public IActionResult ConfirmAddItem([FromRoute] int id, [FromForm] Item Item)
        {
            
            Item.CayegoryId = id;

            _itemDb.Add(Item);
            return RedirectToAction(nameof(ShowItemsList), new { id = Item.CayegoryId });
        }

        public IActionResult Edit([FromRoute] int id)
        {
            Item Item = _itemDb.GetById(id);

            return View(Item);
        }


        [HttpPost]
        public IActionResult Update([FromForm] Item Item, [FromRoute] int id, [FromQuery] int CategoryId)
        {
            Item.Id = id;
            Item.CayegoryId = CategoryId;
            _itemDb.Update(Item);

            return RedirectToAction(nameof(ShowItemsList), new { id = Item.CayegoryId });
        }

        public IActionResult Delete([FromRoute] int id)
        {
            Item Item = _itemDb.GetById(id);
            return View(Item);
        }

        [HttpPost]
        public IActionResult ConfirmDelete([FromRoute] int id, [FromQuery] int CategoryId)
        {
            _itemDb.Delete(id);
            return RedirectToAction(nameof(ShowItemsList), new { id = CategoryId });
        }

        public IActionResult AddItemToStore()
        {
            ItemStore itemStore = new ItemStore();
            return View(itemStore);
        }

        public IActionResult ConfirmAddItemToStore([FromRoute] int id, [FromQuery] int StoreId, [FromQuery] int CategoryId)
        {
            ItemStore itemStore = new ItemStore();
            itemStore.ItemId = id;
            itemStore.StoreId = StoreId;

            _itemStoreDb.Add(itemStore);
            return RedirectToAction(nameof(ShowItemsList), new { id = CategoryId });
        }

        public IActionResult DeleteItemFromStore([FromRoute] int id, [FromQuery] int StoreId)
        {
            ItemStore itemStore = _itemStoreDb.GetByItemIdAndStoreId(id, StoreId);
            return View(itemStore);
        }

        public IActionResult ConfirmDeleteItemFromStore([FromRoute] int id, [FromQuery] int StoreId)
        {
            _itemStoreDb.DeleteItemFromStore(id, StoreId);
            return RedirectToAction(nameof(Index));
        }

    }
}
