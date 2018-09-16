using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LearningMVC.Json.Web_Api
{
    public static class ViewHelpers
    {
        public static JsonSerializerSettings CamelCase
        {
            get
            {
                return new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
            }
        }
    }
}