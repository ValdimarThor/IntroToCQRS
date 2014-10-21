using NServiceBus;

namespace EventProcessor.NServiceBus.Config
{
    public class LoggingConfig : IWantToRunWhenBusStartsAndStops
    {
        public void Start()
        {
            
            
        }

        public void Stop()
        {
            // Do nothing...
        }
    }
}
