using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class AnimalFoodService
    {
        ZooContext db =new ZooContext();

        public List<ViewFoodTotal> GetViewFoodTotals()
        {
            IQueryable<IGrouping<int, AnimalFood>> animalFoodGroups = db.AnimalFoods.GroupBy(x => x.FoodId);
            IQueryable<ViewFoodTotal> foodTotals =
                from foodGroup in animalFoodGroups
                let totalQuantity = foodGroup.Sum(x => x.Animal.Quantity*x.Quantity)
                let food = foodGroup.FirstOrDefault()
                select new ViewFoodTotal()
                {
                    FoodPrice = food.Food.Price,
                    FoodName = food.Food.Name,
                    TotalQuantity = totalQuantity,
                    TotalPrice = totalQuantity*food.Food.Price,
                    Id = food.Id,
                    FoodId = food.FoodId
                };
            return foodTotals.ToList();
        }

        public List<ViewFoodAnimalTotal> GetViewFoodTotalsByFood(int foodId)
        {
            IQueryable<AnimalFood> animalFoods = db.AnimalFoods.Where(x=>x.FoodId==foodId);
            var totals = animalFoods.Select(animalFood => new ViewFoodAnimalTotal()
            {
                Id = animalFood.Id,
                AnimalName = animalFood.Animal.Name,
                TotalQuantity = animalFood.Quantity*animalFood.Animal.Quantity,
                TotalPrice = animalFood.Quantity*animalFood.Animal.Quantity*animalFood.Food.Price,
            }).ToList();
            return totals;
        }
    }
}
