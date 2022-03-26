using StockManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Data
{
    public class ImageDb
    {
        private readonly StockDbContext _context;
        public ImageDb(StockDbContext context)
        {
            _context = context;
        }

        public List<Image> GetByItemId(int ItemId)
        {
            return _context.Images.Where(x => x.ItemId == ItemId).ToList();
        }

        public Image Add(Image image)
        {
            _context.Images.Add(image);
            _context.SaveChanges();
            return image;
        }

    }
}
