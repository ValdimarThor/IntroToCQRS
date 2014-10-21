using System.Web.Http;
using DependencyResolution.Resolvers;
using Microsoft.Owin;
using Owin;
using web;

[assembly: OwinStartup(startupType: typeof(DependencyResolution.Web.Startup))]
namespace DependencyResolution.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = ContainerBuilder.Build();
            var configuration = new HttpConfiguration
            {
                DependencyResolver = new StructureMapResolver(container)
            };

            WebApiConfig.Register(configuration);

            app.UseWebApi(configuration);
        }
    }
}
