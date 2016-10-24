using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PatStore.Controllers
{
    [Log]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string url = HttpContext.Request.Url.ToString();

            if (url.Contains("pat"))
                return Json("Hi, Pat!", JsonRequestBehavior.AllowGet);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.NewProperty = "Testing viewbag";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            Session.Add("Product", new Models.Product { Location = "Some product", Price = 5.95m });
            Response.SetCookie(new HttpCookie("MyCookieName", "MyCookieValue") { Expires = DateTime.Now.AddMinutes(5) });
            return View();
        }

        public ActionResult Products()
        {
            return Json(new
            {
                Name = "Dodecahedron",
                Price = 1.95m,
                Description = "This gem is a test",
            }, JsonRequestBehavior.AllowGet);            
        }
    }
}