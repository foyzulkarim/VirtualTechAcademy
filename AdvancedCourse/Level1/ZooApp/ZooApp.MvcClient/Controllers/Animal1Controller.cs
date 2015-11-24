using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooApp.Models;
using ZooApp.Services;
using ZooApp.ViewModels;

namespace ZooApp.MvcClient.Controllers
{
    public class Animal1Controller : Controller
    {
        AnimalService service = new AnimalService();

        // GET: Animal1
        public ActionResult Index()
        {
            var viewAnimals = service.GetAll();
            return View(viewAnimals);
        }

        public ActionResult Details(int id)
        {
            ViewAnimal animal = service.Get(id);
            return View(animal);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Animal animal)
        {
            // save 
            bool saved = service.Save(animal);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Animal animal = service.GetDbModel(id);
            return View(animal);
        }

        [HttpPost]
        public ActionResult Edit(Animal animal)
        {
            // save 
            bool saved = service.Update(animal);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(service.GetDbModel(id));
        }

        [HttpPost]
        public ActionResult Delete(Animal animal)
        {
            // save 
            bool saved = service.Delete(animal);
            return RedirectToAction("Index");
        }
    }
}