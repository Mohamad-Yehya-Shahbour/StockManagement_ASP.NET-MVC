using StockManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockManagement.ViewModel;

namespace StockManagement.Data
{
    public class CategoryStoreDb
    {
        private readonly StockDbContext _context;
        private readonly CategoryDb _categoryDb;
        public CategoryStoreDb(StockDbContext context, CategoryDb categoryDb )
        {
            _categoryDb = categoryDb;
            _context = context;
        }

        public List<CategoryStoreVM> GetCategoryByStoreId(int storeId)
        {
           
            List<CategoryStoreVM> CategoryStorelist = (from categ in _context.Categories

                                                       join cs in _context.CategoryStores
                                                       on categ.Id equals cs.CategoryId
                                                     

                                                       where cs.StoreId == storeId
                                                       select new CategoryStoreVM
                                                       {
                                                           CategoryStoreId = cs.CategoryStoreId,
                                                           CategoryId = cs.CategoryId,
                                                           StoreId = cs.StoreId,
                                                           CategoryName = categ.Name,

                                                       }
                                                            ).ToList();
            //List<CategoryStoreVM> CategoryStorelist = new List<CategoryStoreVM>();
            //CategoryStorelist.Add(new CategoryStoreVM
            //{CategoryName = "bahbahbha",

            //});
            return CategoryStorelist;
        }

        public CategoryStore Add(CategoryStore categoryStore)
        {
            _context.CategoryStores.Add(categoryStore);
            _context.SaveChanges();
            return categoryStore;
        }

        public CategoryStore GetByCategIdAndStoreId(int categoryId, int storeId)
        {
            return _context.CategoryStores.FirstOrDefault(x => x.CategoryId == categoryId && x.StoreId == storeId);
        }

        public void DeleteCategFromStore(int categoryId, int storeId)
        {
            CategoryStore categoryStore = GetByCategIdAndStoreId(categoryId, storeId);
            if (categoryStore != null)
            {
                _context.CategoryStores.Remove(categoryStore);
                _context.SaveChanges();
            }
        }
    }
}
