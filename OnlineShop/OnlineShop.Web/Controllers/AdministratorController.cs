using OnlineShop.Entities;
using OnlineShop.Services;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Entities.Enums;

namespace OnlineShop.Web.Controllers
{
    [Authorize]
    public class AdministratorController : Controller
    {
        ProductService ProductService;
        public AdministratorController()
        {
            ProductService = new ProductService();
        }

        //[AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(string name, double price, string description, Category kindOfGoods, Brand brand, HttpPostedFileBase uploadImage)
        {
            byte[] imageData = null;
            if (uploadImage != null)
            {
                // var previosCover = editMagazine.Covers.FirstOrDefault();
                // editMagazine.Covers.Remove(previosCover);
                imageData = ImageProcessing.ImageSaver(uploadImage);
                //   editMagazine.Covers.Add(new Cover { CoverForModels = imageData });
            }
            if (name != null && price.ToString() != null)
            {
                var newProduct = new Product
                {
                    Name = name,
                    Price = price,
                    Description = description,
                    KindOfGoods = kindOfGoods,
                    Brand = brand,
                    Picture = imageData
                };
                ProductService.AddNewProduct(newProduct);
                return View();
            }
            return View();
        }

    }
}