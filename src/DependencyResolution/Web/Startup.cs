using System.Web.Http;
using DependencyResolution.Resolvers;
using Microsoft.Owin;
using Owin;
using ShortBus;
using StructureMap;
using StructureMap.Graph;
using Web;
using Startup = DependencyResolution.Web.Startup;

[assembly: OwinStartup(startupType: typeof(Startup))]
namespace DependencyResolution.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = ContainerBuilder.Build();

            // Wire up mediator pattern
            ObjectFactory.Initialize(i => i.Scan(s =>
            {
                s.AssemblyContainingType<IMediator>();
                s.TheCallingAssembly();
                s.WithDefaultConventions();
                s.AddAllTypesOf(typeof(IQueryHandler<,>));
                s.AddAllTypesOf(typeof(ICommandHandler<>));
            })); 

            // Wire up IoC to MVC and Web API Dependency Resolver
            var configuration = new HttpConfiguration
            {
                DependencyResolver = new StructureMapResolver(container)
            };
            WebApiConfig.Register(configuration);
        }
    }
}
