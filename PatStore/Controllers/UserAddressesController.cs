//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using PatStore.Models;

//namespace PatStore.Controllers
//{
//    [Authorize]
//    public class UserAddressesController : Controller
//    {
//        private PatStoreDBEntities db = new PatStoreDBEntities();

//        // GET: UserAddresses
//        public ActionResult Index()
//        {
//            var userAddresses = db.Users.Include(u => u.User);
//            return View(db.Users.Single(x => x.Email == User.Identity.Name).UserAddresses.Select(x => x.Address).ToList());
//        }

//        // GET: UserAddresses/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            UserAddress userAddress = db.UserAddresses.Find(id);
//            if (userAddress == null)
//            {
//                return HttpNotFound();
//            }
//            return View(userAddress);
//        }

//        // GET: UserAddresses/Create
//        public ActionResult Create()
//        {
//            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
//            return View();
//        }

//        // POST: UserAddresses/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,Address,Address2,City,State,ZipCode,UserId")] UserAddress userAddress)
//        {
//            //userAddress.rowguid = Guid.NewGuid();
//            //userAddress.ModifiedDate = DateTime.UtcNow
//            if (ModelState.IsValid)
//            {
//                db.UserAddresses.Add(userAddress);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", userAddress.UserId);
//            return View(userAddress);
//        }

//        // GET: UserAddresses/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            UserAddress userAddress = db.UserAddresses.Find(id);
//            if (userAddress == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", userAddress.UserId);
//            return View(userAddress);
//        }

//        // POST: UserAddresses/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,Address,Address2,City,State,ZipCode,UserId")] UserAddress userAddress)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(userAddress).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", userAddress.UserId);
//            return View(userAddress);
//        }

//        // GET: UserAddresses/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            UserAddress userAddress = db.UserAddresses.Find(id);
//            if (userAddress == null)
//            {
//                return HttpNotFound();
//            }
//            return View(userAddress);
//        }

//        // POST: UserAddresses/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            UserAddress userAddress = db.UserAddresses.Find(id);
//            db.UserAddresses.Remove(userAddress);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
