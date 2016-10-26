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
        public int Id { get; private set; }

        //GET: Checkout
        public ActionResult Index()
        {           
            if (User.Identity.IsAuthenticated)
            {
                using (PatStore.Models.PatStoreDBEntities entities = new PatStoreDBEntities())
                {
                    CartModel model = new CartModel();
                    var user = entities.Users.First(x => x.Email == User.Identity.Name);
                    var cart = user.OrderInfoes.First();
                    var pay = user.PaymentInfoes.First();
                    var prod = cart.Product;
                    model.Location = prod.Location;
                    model.Total = prod.Price;
                    model.Address1 = user.Address;
                    model.Address2 = user.Address2;
                    model.City = user.City;
                    model.State = user.State;
                    model.Zip = user.ZipCode;
                    model.CreditCardName = pay.CreditCardName;
                    model.CreditCardNumber = pay.CreditCardNumber;
                    model.CreditCardAddress1 = pay.CreditCardAddress1;
                    model.CreditCardAddress2 = pay.CreditCardAddress2;
                    model.CreditCardCity = pay.CreditCardCity;
                    model.CreditCardState = pay.CreditCardState;
                    model.CreditCardPostal = pay.CreditCardPostal;

                    //model.Product = new Product
                    //{
                    //    Location = prod.Location
                    //};
                    //model.User = new Models.User
                    //{
                    //    FirstName = user.FirstName
                    //};
                    return View(model);
                }                 
            }
            return RedirectToAction("Index", "Checkout");
        }

        [HttpPost]
        public ActionResult Index(CartModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO: Save checkout information to database.
                if (User.Identity.IsAuthenticated)
                {
                    using (PatStore.Models.PatStoreDBEntities entities = new PatStoreDBEntities())
                    {
                        //CartModel model = new CartModel();
                        //OrderInfo order = new OrderInfo();                       
                        //cart.ProdId = prod.Id;
                        //cart.Email = user.Email;
                        //cart.FirstName = user.FirstName;
                        //cart.LastName = user.LastName;
                        //cart.Phone = user.PhoneNumber;
                        //cart.Address1 = user.Address;
                        //cart.Address2 = user.Address2;
                        //cart.City = user.City;
                        //cart.State = user.State;
                        //pay.CreditCardNumber = model.CreditCardNumber;
                        //pay.CreditCardName = model.CreditCardName;
                        //pay.CreditCardAddress1 = model.CreditCardAddress1;
                        //pay.CreditCardAddress2 = model.CreditCardAddress2;
                        //pay.CreditCardCity = model.CreditCardCity;
                        //pay.CreditCardState = model.CreditCardState;
                        //pay.CreditCardPostal = model.CreditCardPostal;
                        //entities.OrderInfoes.Add(order);                        
                        //entities.PaymentInfoes.Add(model);
                        entities.SaveChanges();
                    }
                }
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