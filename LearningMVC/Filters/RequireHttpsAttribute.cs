﻿using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

//Can put in global.asax for entire application.
namespace LearningMVC.Filters
{
    public class RequireHttpsAttribute: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var request = actionContext.Request;

            if(request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                var html = "<p>Https needed</p>";

                if(request.Method.Method == "GET")
                {
                    actionContext.Response = request.CreateResponse(HttpStatusCode.NotFound);
                    actionContext.Response.Content = new StringContent(html, Encoding.UTF8, "text/html");

                    var uriBuilder = new UriBuilder(request.RequestUri);
                    uriBuilder.Scheme = Uri.UriSchemeHttps;
                    uriBuilder.Port = 443; //ssl port

                    actionContext.Response.Headers.Location = uriBuilder.Uri;
                }
                else
                {
                    actionContext.Response = request.CreateResponse(HttpStatusCode.NotFound);
                    actionContext.Response.Content = new StringContent(html, Encoding.UTF8, "text/html");
                }
            }
        }
    }
}