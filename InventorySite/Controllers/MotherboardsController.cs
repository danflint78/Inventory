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
    public class MotherboardsController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        // GET: Motherboards
        public ActionResult Index()
        {
            var motherboards = db.Motherboards.Include(m => m.Computer);
            return View(motherboards.ToList());
        }

        // GET: Motherboards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motherboard motherboard = db.Motherboards.Find(id);
            if (motherboard == null)
            {
                return HttpNotFound();
            }
            return View(motherboard);
        }

        // GET: Motherboards/Create
        public ActionResult Create()
        {
            ViewBag.ComputerID = new SelectList(db.Computers, "ComputerID", "Name");
            return View();
        }

        // POST: Motherboards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MotherboardID,Make,Model,NumberOfDisplayPorts,NumberOfMemoryPorts,HasParallelPort,ComputerID")] Motherboard motherboard)
        {
            if (ModelState.IsValid)
            {
                db.Motherboards.Add(motherboard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComputerID = new SelectList(db.Computers, "ComputerID", "Name", motherboard.ComputerID);
            return View(motherboard);
        }

        // GET: Motherboards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motherboard motherboard = db.Motherboards.Find(id);
            if (motherboard == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComputerID = new SelectList(db.Computers, "ComputerID", "Name", motherboard.ComputerID);
            return View(motherboard);
        }

        // POST: Motherboards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MotherboardID,Make,Model,NumberOfDisplayPorts,NumberOfMemoryPorts,HasParallelPort,ComputerID")] Motherboard motherboard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motherboard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComputerID = new SelectList(db.Computers, "ComputerID", "Name", motherboard.ComputerID);
            return View(motherboard);
        }

        // GET: Motherboards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motherboard motherboard = db.Motherboards.Find(id);
            if (motherboard == null)
            {
                return HttpNotFound();
            }
            return View(motherboard);
        }

        // POST: Motherboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Motherboard motherboard = db.Motherboards.Find(id);
            db.Motherboards.Remove(motherboard);
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
