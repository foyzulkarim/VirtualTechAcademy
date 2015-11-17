using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooApp.Services;

namespace ZooApp.MvcClient.Controllers
{
    public class Animal1Controller : Controller
    {
        // GET: Animal1
        public ActionResult Index()
        {
            AnimalService service=new AnimalService();
            var viewAnimals = service.GetAnimals();
            return View(viewAnimals);
        }
    }
}