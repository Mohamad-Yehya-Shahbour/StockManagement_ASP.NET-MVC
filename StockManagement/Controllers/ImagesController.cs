using StockManagement.Data;
using StockManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Controllers
{
    public class ImagesController : Controller
    {
        private readonly ImageDb _imageDb;

        public ImagesController(ImageDb imageDb)
        {
            _imageDb = imageDb;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddImage()
        {
            Image image = new Image();
            return View(image);
        }

        public IActionResult ConfirmAddImage([FromForm] Image image, [FromRoute] int id)
        {
            string uniqueId = Guid.NewGuid().ToString();
            string destination = Path.Combine("wwwroot", "images", "items", uniqueId + ".jpg");
            using (FileStream fs = new FileStream(destination, FileMode.Create))
            {
                image.formFile.CopyTo(fs);
            }
            string dbUrl = destination.Replace("wwwroot", "");


            image.ImageUrl = dbUrl;
            image.ItemId = id;
            _imageDb.Add(image);
            return RedirectToAction("Index", "Items");
        }



    }
}
