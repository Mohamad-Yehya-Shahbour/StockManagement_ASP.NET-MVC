using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Models
{
    public class Branche
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }


        public virtual ICollection<Store> ListStore { get; set; }
    }
}
