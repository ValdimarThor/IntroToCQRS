using StructureMap.Configuration.DSL;

namespace DependencyResolution.Core
{
    public class MarketingRegistry : Registry
    {
        public MarketingRegistry()
        {
            //For<IFoo>().Use<Foo>();
        }
    }
}