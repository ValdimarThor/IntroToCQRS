using StructureMap.Configuration.DSL;

namespace DependencyResolution.Core
{
    public class OrdersRegistry : Registry
    {
        public OrdersRegistry()
        {
            //For<IFoo>().Use<Foo>();
        }
    }
}