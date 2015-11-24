using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;

namespace ZooApp.ViewModels
{
    public class ViewFoodTotal
    {
        public ViewFoodTotal()
        {
            
        }

        public ViewFoodTotal(AnimalFood animalFood)
        {
            FoodName = animalFood.Food.Name; // grass
            FoodPrice = animalFood.Food.Price; // 10
            TotalQuantity = animalFood.Animal.Quantity*animalFood.Quantity;// 3 * 3 = 9
            TotalPrice = FoodPrice * TotalQuantity;
        }

        public double TotalPrice { get; set; } // OOP Concept. 

        public double TotalQuantity { get; set; }

        public double FoodPrice { get; set; }

        public string FoodName { get; set; }
    }
}
