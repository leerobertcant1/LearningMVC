using LearningMVC.Data.Web_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearningMVC.Controllers.Web_API
{
    
    public class TokenController : BaseApiController
    {

        public HttpResponseMessage Post([FromBody] TokenRequestModel tokenModel)
        {
            User user = this.UserRepository.GetApiUsers()
                                          .Select(u => u)
                                          .FirstOrDefault();

            if(user != null)
            {
                try
                {
                    //Secrets and token stuff goes here
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest, "General error");
            }

            return Request.CreateResponse(HttpStatusCode.NoContent, "No user");

        }
    }

   
}
