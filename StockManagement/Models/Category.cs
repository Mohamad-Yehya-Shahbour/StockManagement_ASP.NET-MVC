using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CategoryStore> ListCategoryStore { get; set; }
        public virtual ICollection<Item> ListItem { get; set; }
    }
}
