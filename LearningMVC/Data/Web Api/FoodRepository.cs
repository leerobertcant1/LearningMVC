using LearningMVC.Models.Web_APIs;
using System.Collections.Generic;

namespace LearningMVC.Data
{
    public class FoodRepository : IFoodRepository
    {
        public IEnumerable<Food> GetFoods()
        {
            return new List<Food>()
            {
                new Food { Id = 1, Description = "Chips", Measure = new Measure {Id = 1, Total = 500, Unit = "g" } },
                new Food { Id = 1, Description = "Cake" , Measure = new Measure {Id = 2,Total = 20, Unit = "g" } },
                new Food { Id = 2, Description = "Coke" , Measure = new Measure { Id = 2,Total = 500, Unit = "ml"}},
                new Food { Id = 3, Description = "Chocolate", Measure = new Measure {Id = 3,Total = 20, Unit = "g" } }
            };
        }
    }
}
