using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace LearningMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Stops this accessing files
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Order matters first one that matters wins.
            //add using rightclick add controller.

            //Me/Lee/? {is dynamic}, the dynamic option needs a default value.
            //or uuse urlparameter.optional to ignore it - or set default value in code.
            routes.MapRoute("Test",
                "Test/Encode/{number}",
                new {controller = "Test", Action = "Lee", number= 0}
                );

            routes.MapRoute("MeRedirect",
               "Test/Redirect/{number}",
               new { controller = "Test", Action = "Redirect", number = 0 }
               );

            routes.MapRoute("GetCSS",
               "Test/CSS/ {random}",
                new {controller = "Test", Action = "CSS", random = UrlParameter.Optional}
                );

            routes.MapRoute("GetJSON",
             "Test/json",
              new { controller = "Test", Action = "JSON"}
              );

            routes.MapRoute("Data",
                "Data/Index",
                 new { controller = "Data", Action = "Index" }
            );
            routes.MapRoute("DataEdit",
            "Data/Edit/{id}",
             new { controller = "Data", Action = "Edit", id = Guid.NewGuid()}
        );

            routes.MapRoute("DataXSSTest",
              "Data/XSSTest",
               new { controller = "Data", Action = "XSSTest" }
          );

            routes.MapRoute("AJAX",
               "AJAX/Index/ {page}",
                new { controller = "AJAX", Action = "Index" }
           );

            routes.MapRoute("AutoComplete",
                "AJAX/AutoComplete/{term}",
                new { controller = "AJAX", Action = "AutoComplete", page = 0}
                );

            routes.MapHttpRoute(
             name: "Measures",
             routeTemplate: "api/foods/{foodId}/measures",
             defaults: new { controller = "measures", action = "Get" }
         );

            //FoodId not optional, hence not listed.
            routes.MapHttpRoute(
            name: "MeasuresById",
            routeTemplate: "api/foods/{foodId}/measures/{id}",
            defaults: new { controller = "measures", action = "Get", id = UrlParameter.Optional }
        );

            routes.MapHttpRoute(
                 name: "MeasuresPost",
                 routeTemplate: "api/foods/{foodId}/measures/Post/{id}",
                 defaults: new { controller = "measures", action = "Post", id = UrlParameter.Optional }
        );

            routes.MapHttpRoute(
                 name: "MeasuresDelete",
                 routeTemplate: "api/foods/{foodId}/measures/Delete/{id}",
                 defaults: new { controller = "measures", action = "Delete"}
        );

            routes.MapHttpRoute(
                name: "MeasuresPut",
                routeTemplate: "api/foods/{foodId}/measures/Put/{id}",
                defaults: new { controller = "measures", action = "Put" }
       );

            routes.MapHttpRoute(
                 name:"Food",
                 routeTemplate: "api/foods",
                 defaults: new { controller = "foods", action = "Get"}
             );

            routes.MapHttpRoute(
                 name: "FoodById",
                 routeTemplate: "api/foods/{id}",
                 defaults: new { controller = "foods", action = "GetById", id = UrlParameter.Optional }
             );

            //Home/index?? default action index.
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
