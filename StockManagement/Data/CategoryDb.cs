using StockManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Data
{
    public class CategoryDb
    {
        private readonly StockDbContext _context;
        public CategoryDb(StockDbContext context)
        {
            _context = context;
        }

        public Category Add(Category Category)
        {
            _context.Categories.Add(Category);
            _context.SaveChanges();
            return Category;
        }

        public Category Update(Category Category)
        {
            Category categorydb = GetById(Category.Id);
            if (categorydb != null)
            {
                categorydb.Name = Category.Name;
                _context.SaveChanges();
            }
            return Category;
        }

        public void Delete(int CategoryId)
        {
            Category category = GetById(CategoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public Category GetById(int CategoryId)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == CategoryId);
        }

        public List<Category> Get()
        {
            return _context.Categories.ToList();
        }
    }
}
