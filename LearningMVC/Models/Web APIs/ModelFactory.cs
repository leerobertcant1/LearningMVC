using System.Net.Http;
using System.Text.RegularExpressions;

namespace LearningMVC.Models.Web_APIs
{
    public class ModelFactory:IModelFactory
    {
        private HttpRequestMessage _request;

        public ModelFactory(HttpRequestMessage requestMessage)
        {   
            _request = requestMessage;
        }
        public FoodModel CreateFoodModel(Food food)
        {
            return new FoodModel
            {
                Url = $"{_request.RequestUri}/{food.Id}",
                Description = food.Description,
                Measure = CreateMeasureModel(food.Measure, food)
            };
        }

        public MeasureModel CreateMeasureModel(Measure measure, Food food) 
        {      
            return new MeasureModel
            {
                Url = Regex.IsMatch(_request.RequestUri.ToString(), @"\d+(\.\d+)?$") ? 
                                                                    $"{_request.RequestUri}" : $"{_request.RequestUri}/{measure.Id}",
                Total = measure.Total,
                Unit = measure.Unit
            };
        }
    }
}