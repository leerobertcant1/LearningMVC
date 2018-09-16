using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LearningMVC.Controllers.Web_API2
{
    [RoutePrefix("api/stats")] //- this adds the prefix in front of all the method calls
    public class WebAPI2Controller : ApiController
    {
        //web api2 looks like this needs more up to date version though.
        //Tilda(~) means ignore the prefix
        [Route("~api/v2/webapi2")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Json("Api2 data returned"));
        }

        //Id adds parameters
        [Route("webapi2/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, Json("Api2 data returned"));
        }

        //still needed for an empty method
        [Route("")]
        public HttpResponseMessage GetEmpty()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Json(""));
        }

        //alpha is a constraint that says go here first(also length, max length, etc)
        [Route("~api/v2/webapi2/{name:alpha}")]
        public HttpResponseMessage GetConstraints(string name)
        {
            return Request.CreateResponse(HttpStatusCode.OK, Json(""));
        }

        //Can just find this automatically and pass in value and find via name
        [Route("{value:int}", Name ="Attributes")]
        [DisableCors]//Can turn off
        public HttpResponseMessage GetAttributes(int value)
        {
            return Request.CreateResponse(HttpStatusCode.OK, Json(value.ToString()));
        }

        //CORS means when one website calls another
        [Route("webapi2/cors")]
        [EnableCors("*", "*", "GET")] // Website/ Headers/MethodNuget package needed for this (System.Web.Http.Cors).
        public HttpResponseMessage GetCors()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Json("cors"));
        }

        //IhttpActionResult simplified version
        [Route("webapi2/actionResult")]
        public IHttpActionResult GetActionResultsOk()
        {
            return Ok(Json("ok")); // Returns okay message with message inside
        }

        [Route("webapi2/actionResult")]
        public IHttpActionResult GetActionResultsNotFound()
        {
            return NotFound(); // Returns notfound, can use others
        }
    }
}
