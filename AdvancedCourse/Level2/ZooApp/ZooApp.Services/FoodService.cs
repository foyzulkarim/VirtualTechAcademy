using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class FoodService
    {
        ZooContext db = new ZooContext();

        public List<ViewFood> GetAll()
        {
            var list = db.Foods.ToList();
            var viewFoods = new List<ViewFood>();
            foreach (var l in list)
            {
                var viewFood = new ViewFood(l);
                
                viewFoods.Add(viewFood);
            }
            
            return viewFoods;
        }

        public ViewFood Get(int id)
        {
            var find = db.Foods.Find(id);
            return new ViewFood(find);
        }

        public bool Save(Food food)
        {
            db.Foods.Add(food);
            db.SaveChanges();
            return true;
        }

        public bool Update(Food food)
        {
            db.Entry(food).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public bool Delete(Food food)
        {
            Food entity = db.Foods.Find(food.Id);
            db.Foods.Remove(entity);
            db.SaveChanges();
            return true;
        }

        public Food GetDbModel(int id)
        {
            return db.Foods.Find(id);
        }
    }
}
