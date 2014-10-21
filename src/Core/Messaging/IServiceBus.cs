namespace Core.Messaging
{
    public interface  IServiceBus
    {
        void Publish<T>(T @event) where T : IEvent;

        void Send<T>(T command) where T : ICommand;
    }
}
