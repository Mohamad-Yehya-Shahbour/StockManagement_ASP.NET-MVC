using StockManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Data
{
    public class ItemDb
    {
        private readonly StockDbContext _context;
        public ItemDb(StockDbContext context)
        {
            _context = context;
        }

        public Item Add(Item Item)
        {
            _context.Items.Add(Item);
            _context.SaveChanges();
            return Item;
        }

        public Item Update(Item Item)
        {
            Item itemdb = GetById(Item.Id);
            if (itemdb != null)
            {
                itemdb.Name = Item.Name;
                itemdb.CayegoryId = Item.CayegoryId;
                _context.SaveChanges();
            }
            return Item;
        }

        public void Delete(int ItemId)
        {
            Item item = GetById(ItemId);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }

        public Item GetById(int ItemId)
        {
            return _context.Items.FirstOrDefault(x => x.Id == ItemId);
        }

        public List<Item> Get()
        {
            return _context.Items.ToList();
        }

        public List<Item> GetByCategoryId(int CategoryId)
        {
            return _context.Items.Where(x => x.CayegoryId == CategoryId).ToList();
        }
    }
}
