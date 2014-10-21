using DependencyResolution.Messaging;
using StructureMap;

namespace DependencyResolution
{
    public static class ContainerBuilder
    {
        public static IContainer Build()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<MessagingRegistry>();
            });
            return ObjectFactory.Container;
        }
    }
}
