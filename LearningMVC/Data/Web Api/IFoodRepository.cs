using LearningMVC.Models.Web_APIs;
using System.Collections.Generic;

namespace LearningMVC.Data
{
    public interface IFoodRepository
    {
        IEnumerable<Food> GetFoods();
    }
}