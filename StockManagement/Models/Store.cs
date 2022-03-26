using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(Branche))]
        public int BrancheId { get; set; }

        public virtual ICollection<ItemStore> ListItemStore { get; set; }
        public virtual ICollection<CategoryStore> ListCategoryStore { get; set; }


        public virtual Branche Branche { get; set; }
    }
}
