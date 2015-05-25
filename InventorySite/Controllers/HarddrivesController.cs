using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventorySite.Models;

namespace InventorySite.Controllers
{
    public class HarddrivesController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        // GET: Harddrives
        public ActionResult Index()
        {
            var harddrives = db.Harddrives.Include(h => h.Computer);
            return View(harddrives.ToList());
        }

        // GET: Harddrives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Harddrive harddrive = db.Harddrives.Find(id);
            if (harddrive == null)
            {
                return HttpNotFound();
            }
            return View(harddrive);
        }

        // GET: Harddrives/Create
        public ActionResult Create()
        {
            ViewBag.ComputerID = new SelectList(db.Computers, "ComputerID", "Name");
            return View();
        }

        // POST: Harddrives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HarddriveID,Type,Capacity,ComputerID")] Harddrive harddrive)
        {
            if (ModelState.IsValid)
            {
                db.Harddrives.Add(harddrive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComputerID = new SelectList(db.Computers, "ComputerID", "Name", harddrive.ComputerID);
            return View(harddrive);
        }

        // GET: Harddrives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Harddrive harddrive = db.Harddrives.Find(id);
            if (harddrive == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComputerID = new SelectList(db.Computers, "ComputerID", "Name", harddrive.ComputerID);
            return View(harddrive);
        }

        // POST: Harddrives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HarddriveID,Type,Capacity,ComputerID")] Harddrive harddrive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(harddrive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComputerID = new SelectList(db.Computers, "ComputerID", "Name", harddrive.ComputerID);
            return View(harddrive);
        }

        // GET: Harddrives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Harddrive harddrive = db.Harddrives.Find(id);
            if (harddrive == null)
            {
                return HttpNotFound();
            }
            return View(harddrive);
        }

        // POST: Harddrives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Harddrive harddrive = db.Harddrives.Find(id);
            db.Harddrives.Remove(harddrive);
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
