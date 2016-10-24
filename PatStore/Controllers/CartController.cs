using PatStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatStore.Controllers
{
    public class CartController : Controller
    {
        //GET: Checkout
        public ActionResult Index(int? id)
        {
            using(PatStore.Models.PatStoreDBEntities entities = new PatStoreDBEntities())
            {
                var cart = entities.OrderInfoes.Single(x => x.Id == id);
                OrderInfo model = new OrderInfo();
                model.Total = cart.Total;                                
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Index(CartModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO: Save checkout information to database.
                return RedirectToAction("Index", "Recepit");
            }
            else
            {
                ModelState.AddModelError("anything", "Unable to process. Fix error.");
                return View(model);
            }
        }
    }
}