using DependencyResolution.Core;
using StructureMap;

namespace DependencyResolution
{
    public static class ContainerBuilder
    {
        public static IContainer Build()
        {
            ObjectFactory.Initialize(x => {
                x.AddRegistry<MarketingRegistry>();
                x.AddRegistry<OrdersRegistry>();
            });

            return ObjectFactory.Container;
        }
    }
}
