using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

class WebApiConfig
{
    public static void Register(HttpConfiguration configuration)
    {

        var settings = configuration.Formatters.JsonFormatter.SerializerSettings;
        settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        settings.Formatting = Formatting.Indented;

        configuration.MapHttpAttributeRoutes();

        configuration.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );
    }
}