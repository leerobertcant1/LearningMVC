using LearningMVC.Models.Web_APIs;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace LearningMVC.Controllers.Web_API
{
 //Only works in debug mode so can test
#if !DEBUG
    [RequireHttps]
#endif
    //api//foods
    public class FoodsController : BaseApiController
    {
        //*** Check routing for these ***
   
        //GET: api/nutrition/foods/ *** Basic Model ***
        public IEnumerable<FoodModel> Get()
        {
            return this.FoodsRepository.GetFoods().Select(f => this.ModelFactory.CreateFoodModel(f))
                                                                          .OrderBy(f => f.Description);
        }

        //GET: api/foods/{id} *** Responses ***
        public HttpResponseMessage GetById(int id)
        {
            IEnumerable<FoodModel> foodModel =  this.FoodsRepository.GetFoods().Where(f => f.Id == id)
                                            .Select(f => this.ModelFactory.CreateFoodModel(f))
                                            .OrderBy(f => f.Description);
            if (foodModel.Any())
            {
                return Request.CreateResponse(HttpStatusCode.OK, foodModel);
            }

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }


}
