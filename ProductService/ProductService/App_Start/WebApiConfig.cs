using System.Web.Http;
using System.Web.Http.Routing;
using Microsoft.Web.Http.Routing;

namespace ProductService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Add Api versioning
            config.AddApiVersioning();

            var constraintResolver = new DefaultInlineConstraintResolver()
            {
                ConstraintMap =
                {
                    ["apiVersion"] = typeof( ApiVersionRouteConstraint )
                }
            };
            config.MapHttpAttributeRoutes(constraintResolver);

            // NOTE: This code is commented
            // config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
