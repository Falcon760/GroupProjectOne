﻿using System;
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
    public class RecipesController : Controller
    {
        private RecipeDbEntities1 db = new RecipeDbEntities1();

        // GET: Recipes
        public ActionResult Index(int? SelectedIngredient)
        {
            var ingredients = db.Ingredients.OrderBy(q => q.Name).ToList();
            ViewBag.SelectedIngredient = new SelectList(ingredients, "IngredientID", "Name", SelectedIngredient);
            int departmentID = SelectedIngredient.GetValueOrDefault();
            IQueryable<Recipe> recipes = db.Recipes
            .Where(c => !SelectedIngredient.HasValue || c.Id == SelectedIngredient)
            .OrderBy(d => d.Id)
            .Include(d => d.RecipeIngredients);
            var sql = recipes.ToString();
            return View(recipes.ToList());
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            ViewBag.RecipeCatId = new SelectList(db.RecipeCategories, "Id", "CatName");
            ViewBag.CuisineTypeId = new SelectList(db.CuisineTypes, "CuisineTypeId", "Name");
            ViewBag.IngredientId = new SelectList(db.RecipeIngredients, "IngredientId", "Id");
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,RecipeCatId,RecipeDescription,PrepTime,CookTime,Procedures,CuisineTypeId")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Create", "RecipeIngredients", new { id = recipe.Id});
            }

            ViewBag.RecipeCatId = new SelectList(db.RecipeCategories, "Id", "CatName", recipe.RecipeCatId);
            ViewBag.CuisineTypeId = new SelectList(db.CuisineTypes, "CuisineTypeId", "Name", recipe.CuisineTypeId);
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecipeCatId = new SelectList(db.RecipeCategories, "Id", "CatName", recipe.RecipeCatId);
            ViewBag.CuisineTypeId = new SelectList(db.CuisineTypes, "CuisineTypeId", "Name", recipe.CuisineTypeId);
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,RecipeCatId,RecipeDescription,PrepTime,CookTime,Procedures,CuisineTypeId")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecipeCatId = new SelectList(db.RecipeCategories, "Id", "CatName", recipe.RecipeCatId);
            ViewBag.CuisineTypeId = new SelectList(db.CuisineTypes, "CuisineTypeId", "Name", recipe.CuisineTypeId);
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
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
