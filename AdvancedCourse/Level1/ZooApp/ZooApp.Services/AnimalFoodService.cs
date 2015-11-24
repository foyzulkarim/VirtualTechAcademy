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
            var animalFoods = db.AnimalFoods.ToList();
            List<ViewFoodTotal> totals = new List<ViewFoodTotal>();

            foreach (AnimalFood animalFood in animalFoods)
            {
                ViewFoodTotal foodTotal = new ViewFoodTotal(animalFood);
                totals.Add(foodTotal);
            }
            List<ViewFoodTotal> result = new List<ViewFoodTotal>();

            var groupBy = totals.GroupBy(x => x.FoodName);
            foreach (IGrouping<string, ViewFoodTotal> foodTotals in groupBy)
            {
                double totalPrice = foodTotals.Sum(x => x.TotalPrice);
                double totalQuantity = foodTotals.Sum(x => x.TotalQuantity);
                ViewFoodTotal foodTotal = new ViewFoodTotal()
                {
                    FoodName = foodTotals.Key,
                    FoodPrice = foodTotals.First().FoodPrice,
                    TotalPrice = totalPrice,
                    TotalQuantity = totalQuantity
                };
                result.Add(foodTotal);
            }
            return result;
        }
    }
}
