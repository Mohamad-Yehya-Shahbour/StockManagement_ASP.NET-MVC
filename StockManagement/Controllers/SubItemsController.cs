using StockManagement.Data;
using StockManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Controllers
{

    public class SubItemsController : Controller
    {
        private readonly SubItemDb _subItemDb;

        public SubItemsController(SubItemDb subItemDb)
        {
            _subItemDb = subItemDb;
          
        }
        public IActionResult Index([FromRoute]int id)
        {
            List<SubItem> itemStoresList = _subItemDb.GetByItemId(id);

            return View(itemStoresList);
        }

        public IActionResult Add()
        {
            SubItem subItem = new SubItem();
            return View(subItem);
        }

        [HttpPost]
        public IActionResult ConfirmAdd([FromRoute] int id, [FromForm] SubItem subItem)
        {
            string uniqueId = Guid.NewGuid().ToString();
            string destination = Path.Combine("wwwroot", "images","subItems", uniqueId + ".jpg");
            using (FileStream fs = new FileStream(destination, FileMode.Create))
            {
                subItem.formFile.CopyTo(fs);
            }
            string dbUrl = destination.Replace("wwwroot", "");

            subItem.ItemId = id;
            subItem.ImageUrl = dbUrl;
            _subItemDb.Add(subItem);
            return RedirectToAction(nameof(Index), new { id = subItem.ItemId });
        }

        public IActionResult Edit([FromRoute] int id)
        {
            SubItem subItem = _subItemDb.GetById(id);

            return View(subItem);
        }

        [HttpPost]
        public IActionResult Update([FromForm] SubItem subItem)
        {
            string uniqueId = Guid.NewGuid().ToString();
            string destination = Path.Combine("wwwroot", "images", "subItems", uniqueId + ".jpg");
            using (FileStream fs = new FileStream(destination, FileMode.Create))
            {
                subItem.formFile.CopyTo(fs);
            }
            string dbUrl = destination.Replace("wwwroot", "");

            subItem.ImageUrl = dbUrl;

            _subItemDb.Update(subItem);

            return RedirectToAction(nameof(Index), new { id = subItem.ItemId });
        }

        public IActionResult Delete([FromRoute] int Id)
        {
            SubItem subItem = _subItemDb.GetById(Id);
            return View(subItem);
        }

        [HttpPost]
        public IActionResult ConfirmDelete([FromRoute] int id, [FromQuery] int ItemId)
        {
            _subItemDb.Delete(id);
            return RedirectToAction(nameof(Index), new { id = ItemId });
        }
    }
}
