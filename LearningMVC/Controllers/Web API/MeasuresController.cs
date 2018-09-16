using LearningMVC.Controllers.Web_API;
using LearningMVC.Filters;
using LearningMVC.Models.Web_APIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearningMVC.Controllers
{

    //Only works in debug mode so can test, if not logged in 
    //won't be able to access.
#if !DEBUG
    [Authorize]
    [WebApiAuth]
#endif

    //Only Get implemented due to not having a Database.
    public class MeasuresController : BaseApiController
    {
        // GET: api/foods/{foodId}/measures
        public IEnumerable<MeasureModel> Get(int foodId)
        {
            return this.FoodsRepository.GetFoods()
                                    .Where(f => f.Id == foodId)
                                    .Select(f => this.ModelFactory.CreateMeasureModel(f.Measure, f))
                                    .OrderBy( f => f.Total);                                           
        }

        // GET: api/foods/{foodId}/measures/{id}
        public IEnumerable<MeasureModel> Get(int foodId, int id)
        {
           return this.FoodsRepository.GetFoods()
                                .Where(f => f.Id == foodId && f.Measure.Id == id)
                                .Select(f => this.ModelFactory.CreateMeasureModel(f.Measure, f))
                                .OrderBy(f => f.Total);
        }

        // POST: api/foods/{foodId}/measures/Post/{id} 
        // When testing need to post the the JSON in Body and application/json in header
        [HttpPost]
        public HttpResponseMessage Post([FromBody]MeasureModel measureModel)
        {
            try
            {
                if (measureModel != null)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Data Created");
                }

                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"The following error occured: {ex}");
            }
        }

        // PUT: api/Measures/5
        //Used for editing entire objects normally, so need ID and the body (Can use patch for Partial objects + put for full).
        //When Testing need json objects, etc as with post.
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]MeasureModel measureModel)
        {
            try
            {
                if (measureModel != null)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Data Edited");
                }

                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"The following error occured: {ex}");
            }
        }

        // DELETE: api/foods/{foodId}/measures/Delete/{id} 
        //When Testing only need url with no headers for this
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Item Deleted");
                }

                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"The following error occured: {ex}");
            }
        }
    }
}
