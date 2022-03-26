using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Models
{
    public class SubItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ImageUrl { get; set; }


        [NotMapped]
        public IFormFile formFile { get; set; }

        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }

    }
}
