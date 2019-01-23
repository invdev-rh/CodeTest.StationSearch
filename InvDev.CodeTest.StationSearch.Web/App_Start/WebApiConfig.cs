using System.Web.Http;
using DryIoc;
using DryIoc.WebApi;

namespace InvDev.CodeTest.StationSearch
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.ConfigureRouting()
                .ConfigureDependencyInjection();
        }
    }

    internal static class ConfigExtensions
    {
        internal static HttpConfiguration ConfigureRouting(this HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            return config;
        }

        internal static HttpConfiguration ConfigureDependencyInjection(this HttpConfiguration config)
        {
            new Container()
                //.Register<ILookupService, LookupService>(Reuse.InWebRequest)
                .WithWebApi(config);
            return config;
        }
    }
}
