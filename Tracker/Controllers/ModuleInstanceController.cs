using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tracker.DAL;
using Tracker.Models;

namespace Tracker.Controllers
{
    public class ModuleInstanceController : Controller
    {
        private TrackerContext db = new TrackerContext();

        // GET: ModuleInstance
        public ActionResult Index()
        {
            var moduleInstances = db.ModuleInstances.Include(m => m.Module);
            return View(moduleInstances.ToList());
        }

        // GET: ModuleInstance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleInstance moduleInstance = db.ModuleInstances.Find(id);
            if (moduleInstance == null)
            {
                return HttpNotFound();
            }
            return View(moduleInstance);
        }

        // GET: ModuleInstance/Create
        public ActionResult Create()
        {
            ViewBag.ModuleID = new SelectList(db.Modules, "ModuleID", "ModCode");
            return View();
        }

        // POST: ModuleInstance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModuleInstanceID,ModuleID,SEM,year")] ModuleInstance moduleInstance)
        {
            if (ModelState.IsValid)
            {
                db.ModuleInstances.Add(moduleInstance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModuleID = new SelectList(db.Modules, "ModuleID", "ModCode", moduleInstance.ModuleID);
            return View(moduleInstance);
        }

        // GET: ModuleInstance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleInstance moduleInstance = db.ModuleInstances.Find(id);
            if (moduleInstance == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModuleID = new SelectList(db.Modules, "ModuleID", "ModCode", moduleInstance.ModuleID);
            return View(moduleInstance);
        }

        // POST: ModuleInstance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModuleInstanceID,ModuleID,SEM,year")] ModuleInstance moduleInstance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moduleInstance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModuleID = new SelectList(db.Modules, "ModuleID", "ModCode", moduleInstance.ModuleID);
            return View(moduleInstance);
        }

        // GET: ModuleInstance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleInstance moduleInstance = db.ModuleInstances.Find(id);
            if (moduleInstance == null)
            {
                return HttpNotFound();
            }
            return View(moduleInstance);
        }

        // POST: ModuleInstance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModuleInstance moduleInstance = db.ModuleInstances.Find(id);
            db.ModuleInstances.Remove(moduleInstance);
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
