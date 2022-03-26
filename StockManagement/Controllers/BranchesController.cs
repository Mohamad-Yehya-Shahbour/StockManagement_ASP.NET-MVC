using StockManagement.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockManagement.Models;

namespace StockManagement.Controllers
{
    public class BranchesController : Controller
    {
        private readonly BrancheDb _branche;

        public BranchesController(BrancheDb branche)
        {
            _branche = branche;
        }
        public IActionResult Index()
        {
            List<Branche> BrancheList = _branche.Get();
         
            return View(BrancheList);
        }

        public IActionResult Edit([FromRoute] int Id)
        {
            Branche branche = _branche.GetById(Id);

            return View(branche);
        }

        [HttpPost]
        public IActionResult Update([FromForm]Branche branche)
        {
            _branche.Update(branche);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete([FromRoute] int Id)
        {
            Branche branche = _branche.GetById(Id);
            return View(branche);
        }

        [HttpPost]
        public IActionResult ConfirmDelete([FromRoute] int Id)
        {
            _branche.Delete(Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            Branche branche = new Branche();
            return View(branche);
        }

        public IActionResult ConfirmAdd([FromForm] Branche branche)
        {
            _branche.Add(branche);
            return RedirectToAction(nameof(Index));
        }
    }
}
