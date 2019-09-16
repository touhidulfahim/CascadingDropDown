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
    public class CategoryModelsController : Controller
    {
        private CascadingDbContext db = new CascadingDbContext();

        // GET: CategoryModels
        public ActionResult Index()
        {
            var categories = db.Categories.Include(c => c.Categories);
            return View(categories.ToList());
        }

        // GET: CategoryModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryModels categoryModels = db.Categories.Find(id);
            if (categoryModels == null)
            {
                return HttpNotFound();
            }
            return View(categoryModels);
        }

        // GET: CategoryModels/Create
        public ActionResult Create()
        {
            ViewBag.ParentCategoryID = new SelectList(db.Categories, "ItemCategoryID", "ItemCategoryName");
            return View();
        }

        // POST: CategoryModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemCategoryID,ItemCategoryName,ShortName,ParentCategoryID")] CategoryModels categoryModels)
        {
            if (ModelState.IsValid)
            {
                categoryModels.ItemCategoryID = Guid.NewGuid();
                db.Categories.Add(categoryModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentCategoryID = new SelectList(db.Categories, "ItemCategoryID", "ItemCategoryName", categoryModels.ParentCategoryID);
            return View(categoryModels);
        }

        // GET: CategoryModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryModels categoryModels = db.Categories.Find(id);
            if (categoryModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentCategoryID = new SelectList(db.Categories, "ItemCategoryID", "ItemCategoryName", categoryModels.ParentCategoryID);
            return View(categoryModels);
        }

        // POST: CategoryModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemCategoryID,ItemCategoryName,ShortName,ParentCategoryID")] CategoryModels categoryModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentCategoryID = new SelectList(db.Categories, "ItemCategoryID", "ItemCategoryName", categoryModels.ParentCategoryID);
            return View(categoryModels);
        }

        // GET: CategoryModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryModels categoryModels = db.Categories.Find(id);
            if (categoryModels == null)
            {
                return HttpNotFound();
            }
            return View(categoryModels);
        }

        // POST: CategoryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CategoryModels categoryModels = db.Categories.Find(id);
            db.Categories.Remove(categoryModels);
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
