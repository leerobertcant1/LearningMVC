namespace LearningMVC.Models.Web_APIs
{
    public interface IModelFactory
    {
        FoodModel CreateFoodModel(Food food);

        MeasureModel CreateMeasureModel(Measure measure, Food food);
    }
}