using SmartHomeSystem.Domain.AggregatesModel.HubAggregate;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace SmartHomeSystem.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IClimateControlDevice, ClimateControlDevice>(new TransientLifetimeManager()); //default, object per request
            container.RegisterType<IHumidifierDevice, HumidifierDevice>(new TransientLifetimeManager());
            container.RegisterType<ILightingControlDevice, LightingControlDevice>(new TransientLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
