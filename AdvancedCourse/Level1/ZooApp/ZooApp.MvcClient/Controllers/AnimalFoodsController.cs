using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZooApp.Models;

namespace ZooApp.MvcClient.Controllers
{
    public class AnimalFoodsController : Controller
    {
        private ZooContext db = new ZooContext();

        // GET: AnimalFoods
        public ActionResult Index()
        {
            var animalFoods = db.AnimalFoods.Include(a => a.Animal).Include(a => a.Food);
            return View(animalFoods.ToList());
        }

        // GET: AnimalFoods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalFood animalFood = db.AnimalFoods.Find(id);
            if (animalFood == null)
            {
                return HttpNotFound();
            }
            return View(animalFood);
        }

        // GET: AnimalFoods/Create
        public ActionResult Create()
        {
            ViewBag.AnimalId = new SelectList(db.Animals, "Id", "Name");
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name");
            return View();
        }

        // POST: AnimalFoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AnimalId,FoodId,Quantity")] AnimalFood animalFood)
        {
            if (ModelState.IsValid)
            {
                db.AnimalFoods.Add(animalFood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnimalId = new SelectList(db.Animals, "Id", "Name", animalFood.AnimalId);
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name", animalFood.FoodId);
            return View(animalFood);
        }

        // GET: AnimalFoods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalFood animalFood = db.AnimalFoods.Find(id);
            if (animalFood == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalId = new SelectList(db.Animals, "Id", "Name", animalFood.AnimalId);
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name", animalFood.FoodId);
            return View(animalFood);
        }

        // POST: AnimalFoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AnimalId,FoodId,Quantity")] AnimalFood animalFood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animalFood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimalId = new SelectList(db.Animals, "Id", "Name", animalFood.AnimalId);
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name", animalFood.FoodId);
            return View(animalFood);
        }

        // GET: AnimalFoods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalFood animalFood = db.AnimalFoods.Find(id);
            if (animalFood == null)
            {
                return HttpNotFound();
            }
            return View(animalFood);
        }

        // POST: AnimalFoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnimalFood animalFood = db.AnimalFoods.Find(id);
            db.AnimalFoods.Remove(animalFood);
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
