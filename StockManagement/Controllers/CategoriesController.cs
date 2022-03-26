using StockManagement.Data;
using StockManagement.Models;
using StockManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Controllers
{
    //[Route("/[controller]/[action]/{id?}")]
    public class CategoriesController : Controller
    {
        private readonly CategoryDb _categoryDb;
        private readonly CategoryStoreDb _categoryStore;

        public CategoriesController(CategoryDb category, CategoryStoreDb categoryStoreDb)
        {
            _categoryDb = category;
            _categoryStore = categoryStoreDb;
        }

       [HttpGet(Name = nameof(Index))]
        public IActionResult Index([FromRoute] int id) 
        {
            
            List<CategoryStoreVM> categotyStoreList = _categoryStore.GetCategoryByStoreId(id);
            return View(categotyStoreList);
        }

        public IActionResult ShowCategoryList()
        {
            List<Category> categoryList = _categoryDb.Get();

            return View(categoryList);
        }

        public IActionResult Add()
        {
            Category category = new Category();
            return View(category);
        }

        public IActionResult ConfirmAdd([FromForm] Category category)
        {
            _categoryDb.Add(category);
            return RedirectToAction(nameof(ShowCategoryList));
        }

        public IActionResult Edit([FromRoute] int id)
        {
            Category category = _categoryDb.GetById(id);

            return View(category);
        }

        [HttpPost]
        public IActionResult Update([FromForm] Category category)
        {
            _categoryDb.Update(category);
            return RedirectToAction(nameof(ShowCategoryList));
        }

        public IActionResult Delete([FromRoute] int id)
        {
            Category category = _categoryDb.GetById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult ConfirmDelete([FromRoute] int id)
        {
            _categoryDb.Delete(id);
            return RedirectToAction(nameof(ShowCategoryList));
        }

        public IActionResult AddCategoryToStore()
        {
            CategoryStore categoryStore = new CategoryStore();
            return View(categoryStore);
        }


        public IActionResult ConfirmAddCategoryToStore([FromRoute] int id, [FromQuery] int StoreId)
        {
            CategoryStore categoryStore = new CategoryStore();
            categoryStore.CategoryId = id;
            categoryStore.StoreId = StoreId;

            _categoryStore.Add(categoryStore);
            return RedirectToAction(nameof(Index), new { id = StoreId });
        }

        public IActionResult DeleteCategFromStore([FromRoute] int id, [FromQuery] int StoreId)
        {
            CategoryStore categoryStore = _categoryStore.GetByCategIdAndStoreId(id, StoreId);
            return View(categoryStore);
        }

        public IActionResult ConfirmDeleteCategFromStore([FromRoute] int id, [FromQuery] int StoreId)
        {
            _categoryStore.DeleteCategFromStore(id, StoreId);
            return RedirectToAction(nameof(Index), new { id = StoreId });
        }
    }
}
