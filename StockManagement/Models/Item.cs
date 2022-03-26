using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(Category))]
        public int CayegoryId { get; set; }

        public virtual ICollection<SubItem> ListSubItem { get; set; }
        public virtual ICollection<ItemStore> ListItemStore { get; set; }
        public virtual ICollection<Image> ListImage { get; set; }

        public virtual Category Category { get; set; }
    }
}
