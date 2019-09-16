using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CascadingDropDownApp.Gateway;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Controllers
{
    public class TicketTypeModelsController : Controller
    {
        private CascadingDbContext db = new CascadingDbContext();

        // GET: TicketTypeModels
        public ActionResult Index()
        {
            return View(db.TicketTypes.ToList());
        }

        // GET: TicketTypeModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketTypeModels ticketTypeModels = db.TicketTypes.Find(id);
            if (ticketTypeModels == null)
            {
                return HttpNotFound();
            }
            return View(ticketTypeModels);
        }

        // GET: TicketTypeModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TicketTypeModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketTypeId,TicketTypeName,Description")] TicketTypeModels ticketTypeModels)
        {
            if (ModelState.IsValid)
            {
                ticketTypeModels.TicketTypeId = Guid.NewGuid();
                db.TicketTypes.Add(ticketTypeModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticketTypeModels);
        }

        // GET: TicketTypeModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketTypeModels ticketTypeModels = db.TicketTypes.Find(id);
            if (ticketTypeModels == null)
            {
                return HttpNotFound();
            }
            return View(ticketTypeModels);
        }

        // POST: TicketTypeModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketTypeId,TicketTypeName,Description")] TicketTypeModels ticketTypeModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketTypeModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticketTypeModels);
        }

        // GET: TicketTypeModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketTypeModels ticketTypeModels = db.TicketTypes.Find(id);
            if (ticketTypeModels == null)
            {
                return HttpNotFound();
            }
            return View(ticketTypeModels);
        }

        // POST: TicketTypeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TicketTypeModels ticketTypeModels = db.TicketTypes.Find(id);
            db.TicketTypes.Remove(ticketTypeModels);
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
