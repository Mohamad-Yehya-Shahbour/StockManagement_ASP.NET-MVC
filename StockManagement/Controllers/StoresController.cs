using StockManagement.Data;
using StockManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Controllers
{
    //[Route("/[controller]/[action]/{id?}")]
    public class StoresController : Controller
    {
        private readonly StoreDb _store;

        public StoresController(StoreDb store)
        {
            _store = store;
        }
        public IActionResult Index(int Id)
        {
            List<Store> StoreList = _store.GetByBrancheId(Id);

            return View(StoreList);
        }

        public IActionResult Add()
        {
            Store store = new Store();
            return View(store);
        }

        [HttpPost]
        public IActionResult ConfirmAdd([FromForm] Store store, [FromRoute] int BrancheId)
        {
            
            _store.Add(store);
            return RedirectToAction(nameof(Index), new { id = store.BrancheId });
        }

        public IActionResult Edit([FromRoute] int Id)
        {
            Store store = _store.GetById(Id);

            return View(store);
        }

        [HttpPost]
        public IActionResult Update([FromForm] Store store)
        {
            _store.Update(store);
            return RedirectToAction(nameof(Index), new { id = store.BrancheId });
        }

        public IActionResult Delete([FromRoute] int Id)
        {
            Store store = _store.GetById(Id);
            return View(store);
        }

        [HttpPost]
        public IActionResult ConfirmDelete([FromRoute] int Id, [FromQuery] int BrancheId)
        {
            _store.Delete(Id);
            return RedirectToAction(nameof(Index), new { id = BrancheId });
        }
    }
}
