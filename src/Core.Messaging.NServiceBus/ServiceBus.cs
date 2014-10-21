using Core.Messaging.NServiceBus.Config;
using NServiceBus;

namespace Core.Messaging.NServiceBus
{
    public class ServiceBus : IServiceBus
    {
        private static readonly object SyncObject = new object();

        private static IStartableBus _bus;

        public static IBus Bus
        {
            get
            {
                if (_bus == null)
                {
                    lock (SyncObject)
                    {
                        if (_bus == null)
                        {
                            var config = ServiceBusConfig.InitializeClientConfiguration();

                            _bus = global::NServiceBus.Bus.Create(config);
                            _bus.Start();
                        }
                    }
                }

                return _bus;
            }
        }

        public virtual void Publish<T>(T @event) where T : IEvent
        {
            Bus.Publish(@event);
        }

        public virtual void Send<T>(T command) where T : ICommand
        {
            Bus.Send(command);
        }
    }
}
