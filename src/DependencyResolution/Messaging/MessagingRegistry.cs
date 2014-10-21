using Core.Messaging;
using Core.Messaging.NServiceBus;
using StructureMap.Configuration.DSL;

namespace DependencyResolution.Messaging
{
    public class MessagingRegistry : Registry
    {
        public MessagingRegistry()
        {
            For<IServiceBus>().Use<ServiceBus>();
        }
    }
}
