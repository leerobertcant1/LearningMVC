using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace LearningMVC.Json.Web_Api
{
    public static class JsonConfig
    {
        public static void Configure()
        {
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;

            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}