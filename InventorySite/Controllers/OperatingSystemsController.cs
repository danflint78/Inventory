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
    public class OperatingSystemsController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        // GET: OperatingSystems
        public ActionResult Index()
        {
            var operatingSystems = db.OperatingSystems.Include(o => o.Computer);
            return View(operatingSystems.ToList());
        }

        // GET: OperatingSystems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventorySite.Models.OperatingSystem operatingSystem = db.OperatingSystems.Find(id);
            if (operatingSystem == null)
            {
                return HttpNotFound();
            }
            return View(operatingSystem);
        }

        // GET: OperatingSystems/Create
        public ActionResult Create()
        {
            ViewBag.ComputerID = new SelectList(db.Computers, "ComputerID", "Name");
            return View();
        }

        // POST: OperatingSystems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OperatingSystemID,Name,Version,Architecture,ComputerID")] InventorySite.Models.OperatingSystem operatingSystem)
        {
            if (ModelState.IsValid)
            {
                db.OperatingSystems.Add(operatingSystem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComputerID = new SelectList(db.Computers, "ComputerID", "Name", operatingSystem.ComputerID);
            return View(operatingSystem);
        }

        // GET: OperatingSystems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventorySite.Models.OperatingSystem operatingSystem = db.OperatingSystems.Find(id);
            if (operatingSystem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComputerID = new SelectList(db.Computers, "ComputerID", "Name", operatingSystem.ComputerID);
            return View(operatingSystem);
        }

        // POST: OperatingSystems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OperatingSystemID,Name,Version,Architecture,ComputerID")] InventorySite.Models.OperatingSystem operatingSystem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operatingSystem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComputerID = new SelectList(db.Computers, "ComputerID", "Name", operatingSystem.ComputerID);
            return View(operatingSystem);
        }

        // GET: OperatingSystems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventorySite.Models.OperatingSystem operatingSystem = db.OperatingSystems.Find(id);
            if (operatingSystem == null)
            {
                return HttpNotFound();
            }
            return View(operatingSystem);
        }

        // POST: OperatingSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InventorySite.Models.OperatingSystem operatingSystem = db.OperatingSystems.Find(id);
            db.OperatingSystems.Remove(operatingSystem);
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
