using Newtonsoft.Json.Serialization;
using Programing.API.Attributes;
using Programing.API.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Programing.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new ApiExceptionAttribute());
            config.MessageHandlers.Add(new APIKeyHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.Formatting 
                = Newtonsoft.Json.Formatting.Indented; // json verisini daha düzgün göstermek için
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver
                = new CamelCasePropertyNamesContractResolver(); // property leri camel case formatta verir
        }
    }
}
