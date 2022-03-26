using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using StockManagement.Models;

namespace StockManagement.ViewModel
{
    public class ItemStoreVM
    {
        public int ItemId { get; set; }
        public int StoreId { get; set; }

        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        public int CategoryId { get; set; }
        public List<Image> ImageUrls { get; set; }
    }
}
