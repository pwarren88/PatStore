using PatStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatStore.Controllers
{
    public class ProductListController : Controller
    {
        //Prevents two users from getting access to same cache object
        private static object _syncLock = new object();

        // GET: ProductLoop
        public ActionResult Index(string sortBy, string sortDirection)
        {
            //Create array object
            Product[] model = null;
            string cacheKey = "ProducList" + sortBy + sortDirection;
            Product[] cashedResult = this.HttpContext.Cache.Get(cacheKey) as Product[];

            if (cashedResult == null)
            {
                using (PatStore.Models.PatStoreDBEntities entities = new PatStoreDBEntities())
                {
                    if (!string.IsNullOrEmpty(sortBy))
                    {
                        if (sortBy == "Price")
                        {
                            if (sortDirection == "ASC")
                            {
                                model = entities.Products.OrderBy(x => x.Price).ToArray();
                            }
                            else if (sortDirection == "DESC")
                            {
                                model = entities.Products.OrderByDescending(x => x.Price).ToArray();
                            }
                        }
                        else if (sortBy == "Location")
                        {
                            if (sortDirection == "ASC")
                            {
                                model = entities.Products.OrderBy(x => x.Location).ToArray();
                            }
                            else if (sortDirection == "DESC")
                            {
                                model = entities.Products.OrderByDescending(x => x.Location).ToArray();
                            }
                        }
                    }
                    model = entities.Products.ToArray();
                    HttpContext.Cache.Add(cacheKey, model, null, DateTime.Now.AddMinutes(15), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, null);
                }
            }
            else
            {
                model = cashedResult;
            }
            return View(model);
        }
    }
}