using System;
using System.Configuration;
using System.Linq;
using Core.Messaging.NServiceBus.Config;
using NServiceBus;

namespace EventProcessor.NServiceBus.Config
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, INeedInitialization
    {
        private readonly string[] _args;
        private readonly Action<BusConfiguration> _initialize;

        public EndpointConfig() : this(Environment.GetCommandLineArgs(), ServiceBusConfig.InitializeServerConfiguration) { }

        public EndpointConfig(string[] args, Action<BusConfiguration> initialize = null)
        {
            _args = args;
            _initialize = initialize;
        }

        public void Customize(BusConfiguration configuration)
        {
            configuration.EndpointName(GetEndpointName());

            if (_initialize != null)
                _initialize(configuration);
        }

        private string GetEndpointName()
        {
            var endpointName = GetEndpointNameFromCommandLine();
            if (string.IsNullOrWhiteSpace(endpointName))
            {
                endpointName = ConfigurationManager.AppSettings["EventProcessor/MessageType"] ?? string.Empty;
            }

            switch (endpointName.ToUpperInvariant())
            {
                case "SESSION":
                    return "Api.Commands.Session";
                default:
                    return "Api.Commands.All";
            }
        }

        private string GetEndpointNameFromCommandLine()
        {
            var arg = _args.FirstOrDefault(a => a.ToUpperInvariant().StartsWith("/MESSAGETYPE:"));
            if (!string.IsNullOrWhiteSpace(arg))
            {
                return arg.Split(':')[1] ?? string.Empty;
            }

            return string.Empty;
        }
    }
}
