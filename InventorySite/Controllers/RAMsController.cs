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
    public class RAMsController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        // GET: RAMs
        public ActionResult Index()
        {
            var rAMs = db.RAMs.Include(r => r.Computer);
            return View(rAMs.ToList());
        }

        // GET: RAMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAM rAM = db.RAMs.Find(id);
            if (rAM == null)
            {
                return HttpNotFound();
            }
            return View(rAM);
        }

        // GET: RAMs/Create
        public ActionResult Create()
        {
            ViewBag.ComputerID = new SelectList(db.Computers, "ComputerID", "Name");
            return View();
        }

        // POST: RAMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RamID,Type,Speed,Amount,ComputerID")] RAM rAM)
        {
            if (ModelState.IsValid)
            {
                db.RAMs.Add(rAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComputerID = new SelectList(db.Computers, "ComputerID", "Name", rAM.ComputerID);
            return View(rAM);
        }

        // GET: RAMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAM rAM = db.RAMs.Find(id);
            if (rAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComputerID = new SelectList(db.Computers, "ComputerID", "Name", rAM.ComputerID);
            return View(rAM);
        }

        // POST: RAMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RamID,Type,Speed,Amount,ComputerID")] RAM rAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComputerID = new SelectList(db.Computers, "ComputerID", "Name", rAM.ComputerID);
            return View(rAM);
        }

        // GET: RAMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAM rAM = db.RAMs.Find(id);
            if (rAM == null)
            {
                return HttpNotFound();
            }
            return View(rAM);
        }

        // POST: RAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RAM rAM = db.RAMs.Find(id);
            db.RAMs.Remove(rAM);
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
