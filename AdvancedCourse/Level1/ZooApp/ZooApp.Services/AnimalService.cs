using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class AnimalService
    {
        public List<ViewAnimal> GetAnimals()
        {
            // create a db object
            ZooContext db = new ZooContext();
            // fetch db.animal data
            // pulls all rows from table into RAM
            List<Animal> animals = db.Animals.ToList();
            // convert this data into view data
            List<ViewAnimal> viewAnimals=new List<ViewAnimal>();
            foreach (Animal animal in animals)
            {
                ViewAnimal viewAnimal = new ViewAnimal()
                {
                    Id = animal.Id,
                    Quantity = animal.Quantity,
                    Origin = animal.Origin,
                    Food = animal.Food,
                    Name = animal.Name
                };
                viewAnimals.Add(viewAnimal);
            }
            // return
            return viewAnimals;
        }
    }
}
