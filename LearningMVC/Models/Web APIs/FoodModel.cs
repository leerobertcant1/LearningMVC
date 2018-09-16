namespace LearningMVC.Models.Web_APIs
{
    public class FoodModel: BaseModel
    {
        public string Description { get; set; }
        public MeasureModel Measure { get; set; }
    }
}