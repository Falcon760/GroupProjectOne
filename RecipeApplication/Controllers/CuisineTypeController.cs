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
    public class CuisineTypeController : Controller
    {
        private RecipeDbEntities1 db = new RecipeDbEntities1();

        // GET: /CuisineType/
        public ActionResult Index()
        {
            return View(db.CuisineTypes.ToList());
        }

        // GET: /CuisineType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuisineType cuisinetype = db.CuisineTypes.Find(id);
            if (cuisinetype == null)
            {
                return HttpNotFound();
            }
            return View(cuisinetype);
        }

        // GET: /CuisineType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CuisineType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Name,CuisineTypeId")] CuisineType cuisinetype)
        {
            if (ModelState.IsValid)
            {
                db.CuisineTypes.Add(cuisinetype);
                db.SaveChanges();
                return RedirectToAction("Create","CuisineType");
            }

            return View(cuisinetype);
        }

        // GET: /CuisineType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuisineType cuisinetype = db.CuisineTypes.Find(id);
            if (cuisinetype == null)
            {
                return HttpNotFound();
            }
            return View(cuisinetype);
        }

        // POST: /CuisineType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Name,CuisineTypeId")] CuisineType cuisinetype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuisinetype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cuisinetype);
        }

        // GET: /CuisineType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuisineType cuisinetype = db.CuisineTypes.Find(id);
            if (cuisinetype == null)
            {
                return HttpNotFound();
            }
            return View(cuisinetype);
        }

        // POST: /CuisineType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CuisineType cuisinetype = db.CuisineTypes.Find(id);
            db.CuisineTypes.Remove(cuisinetype);
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
