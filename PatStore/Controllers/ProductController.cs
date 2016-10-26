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
                model.Description = product.Description;
                model.RegionId = product.RegionId;
                model.Image_1 = product.Image_1;
                model.Image_2 = product.Image_2;
                model.Image_3 = product.Image_3;
                model.WeatherLocaterId = product.WeatherLocaterId;
                //comment
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Index(Product model)
        {
            //TO DO: Add Product in Database!
            using (PatStore.Models.PatStoreDBEntities entities = new PatStoreDBEntities())
            {
                //Add order to database and redirect to review page
                var user = entities.Users.Single(x => x.Email == User.Identity.Name);
                OrderInfo detail = new OrderInfo();
                detail.Id = 1;
                detail.ProdId = model.Id;
                detail.UserId = user.Id;
                detail.Total = model.Price;
                detail.PaymentId = 1;
                entities.OrderInfoes.Add(detail);
                entities.SaveChanges();              
            }
            return RedirectToAction("Index", "Cart");
        }
    }
}