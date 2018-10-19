using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SSLChallengeWebApplication.Models;

namespace SSLChallengeWebApplication.Controllers
{
    [Authorize]
    public class MacAddressesController : Controller
    {
        private Entities db = new Entities();

        // GET: MacAddresses
        public ActionResult Index()
        {
            var macAddresses = db.MacAddresses.Include(m => m.AspNetUser);
            return View(macAddresses.ToList());
        }

        // GET: MacAddresses/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MacAddress macAddress = db.MacAddresses.Find(id);
            if (macAddress == null)
            {
                return HttpNotFound();
            }
            return View(macAddress);
        }

        // GET: MacAddresses/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: MacAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mac_Address,UserID,Name,DateIssued")] MacAddress macAddress)
        {
            if (ModelState.IsValid)
            {
                db.MacAddresses.Add(macAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", macAddress.UserID);
            return View(macAddress);
        }

        // GET: MacAddresses/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MacAddress macAddress = db.MacAddresses.Find(id);
            if (macAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", macAddress.UserID);
            return View(macAddress);
        }

        // POST: MacAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mac_Address,UserID,Name,DateIssued")] MacAddress macAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(macAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", macAddress.UserID);
            return View(macAddress);
        }

        // GET: MacAddresses/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MacAddress macAddress = db.MacAddresses.Find(id);
            if (macAddress == null)
            {
                return HttpNotFound();
            }
            return View(macAddress);
        }

        // POST: MacAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MacAddress macAddress = db.MacAddresses.Find(id);
            db.MacAddresses.Remove(macAddress);
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
