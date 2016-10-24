using PatStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatStore.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "ProductList");
            }
            using(PatStore.Models.PatStoreDBEntities entities = new PatStoreDBEntities())
            {
                var product = entities.Products.Single(x => x.Id == id);
                Product model = new Product();
                model.Id = product.Id;
                model.Location = product.Location;
                model.Price = product.Price;
                model.RegionId = product.RegionId;
                model.Image_1 = product.Image_1;
                model.Image_2 = product.Image_2;
                model.Image_3 = product.Image_3;
                model.WeatherLocaterId = product.WeatherLocaterId;
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Index(Product model)
        {
            //TO DO: Add Product in Database!
            using (PatStore.Models.PatStoreDBEntities entities = new PatStoreDBEntities())
            {                                
                //Create Line item
                OrderInfo detail = new OrderInfo();
                detail.ProdId = model.Id;
                var user = entities.Users.Single(x => x.Email == User.Identity.Name);
                detail.Total = model.Price;
                entities.OrderInfoes.Add(detail);
                entities.SaveChanges();                
            }
            return RedirectToAction("Index", "Checkout");
        }
    }
}