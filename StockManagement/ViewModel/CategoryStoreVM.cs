using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StockManagement.ViewModel
{
    public class CategoryStoreVM
    {
        public int CategoryStoreId { get; set; }
        public int CategoryId { get; set; }
        public int StoreId { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}
