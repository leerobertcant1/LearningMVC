using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebMatrix.WebData;

namespace LearningMVC.Filters
{
    public class WebApiAuth: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                return;
            }

            var authHeader = actionContext.Request.Headers.Authorization;

            if(authHeader != null)
            {
                if (authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) 
                    && !string.IsNullOrWhiteSpace(authHeader.Parameter))
                {
                    string rawCredentials = authHeader.Parameter;
                    Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                    string credentials = encoding.GetString(Convert.FromBase64String(rawCredentials));
                    string[] split = credentials.Split(':');

                    string username = split[0];
                    string password = split[1];

                    if (!WebSecurity.Initialized)
                    {
                        WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                    }

                    //Check that credentials are fine so can just return
                    if (WebSecurity.Login(username, password))
                    {
                        //Applies identity
                        var principal = new GenericPrincipal(new GenericIdentity(username), null);
                        Thread.CurrentPrincipal = principal;
                        return;
                    }
                }
            }

            HandleUnAuth(actionContext);
        }

        private void HandleUnAuth(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", "Basic Scheme='Auth' location = 'http://localhost:61812/Logon/Login'");
        }
    }
}