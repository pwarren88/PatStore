using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PatStore.Models;

namespace PatStore.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class RegionAdminController : Controller
    {
        private PatStoreDBEntities db = new PatStoreDBEntities();

        // GET: RegionAdmin
        public ActionResult Index()
        {
            return View(db.RegionInfoes.ToList());
        }

        // GET: RegionAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegionInfo regionInfo = db.RegionInfoes.Find(id);
            if (regionInfo == null)
            {
                return HttpNotFound();
            }
            return View(regionInfo);
        }

        // GET: RegionAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegionAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegionName")] RegionInfo regionInfo)
        {
            if (ModelState.IsValid)
            {
                db.RegionInfoes.Add(regionInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(regionInfo);
        }

        // GET: RegionAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegionInfo regionInfo = db.RegionInfoes.Find(id);
            if (regionInfo == null)
            {
                return HttpNotFound();
            }
            return View(regionInfo);
        }

        // POST: RegionAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegionName")] RegionInfo regionInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regionInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(regionInfo);
        }

        // GET: RegionAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegionInfo regionInfo = db.RegionInfoes.Find(id);
            if (regionInfo == null)
            {
                return HttpNotFound();
            }
            return View(regionInfo);
        }

        // POST: RegionAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegionInfo regionInfo = db.RegionInfoes.Find(id);
            db.RegionInfoes.Remove(regionInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
