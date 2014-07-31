using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecipeApplication;

namespace RecipeApplication.Controllers
{
    public class CuisineTypesController : Controller
    {
        private RecipeDbEntities1 db = new RecipeDbEntities1();

        // GET: CuisineTypes
        public ActionResult Index()
        {
            return View(db.CuisineTypes.ToList());
        }

        // GET: CuisineTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuisineType cuisineType = db.CuisineTypes.Find(id);
            if (cuisineType == null)
            {
                return HttpNotFound();
            }
            return View(cuisineType);
        }

        // GET: CuisineTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CuisineTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,CuisineTypeId")] CuisineType cuisineType)
        {
            if (ModelState.IsValid)
            {
                db.CuisineTypes.Add(cuisineType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cuisineType);
        }

        // GET: CuisineTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuisineType cuisineType = db.CuisineTypes.Find(id);
            if (cuisineType == null)
            {
                return HttpNotFound();
            }
            return View(cuisineType);
        }

        // POST: CuisineTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,CuisineTypeId")] CuisineType cuisineType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuisineType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cuisineType);
        }

        // GET: CuisineTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuisineType cuisineType = db.CuisineTypes.Find(id);
            if (cuisineType == null)
            {
                return HttpNotFound();
            }
            return View(cuisineType);
        }

        // POST: CuisineTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CuisineType cuisineType = db.CuisineTypes.Find(id);
            db.CuisineTypes.Remove(cuisineType);
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
