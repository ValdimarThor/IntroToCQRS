using System;
using System.Diagnostics;
using NServiceBus;

namespace Core.Messaging.NServiceBus.Config
{
    public class ServiceBusConfig
    {
        public static void InitializeServerConfiguration(BusConfiguration config)
        {
            InititializePersistence(config);
            InitializeTransport(config);
            InitializeConventions(config);
        }

        public static BusConfiguration InitializeClientConfiguration()
        {
            var config = new BusConfiguration();

            InititializePersistence(config);
            InitializeTransport(config);
            InitializeConventions(config);

            if (Debugger.IsAttached)
            {
                config.EnableInstallers();
            }

            return config;
        }

        public static void InititializeEncryption(BusConfiguration config)
        {
            config.RijndaelEncryptionService();
        }

        public static void InititializePersistence(BusConfiguration config)
        {
            config.UsePersistence<NHibernatePersistence>();
        }

        public static void InitializeTransport(BusConfiguration config)
        {
            config.UseTransport<SqlServerTransport>();
        }

        public static void InitializeConventions(BusConfiguration config)
        {
            var conventions = config.Conventions();

            conventions.DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("LightSail.Core.Messaging.Commands"));
            conventions.DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("LightSail.Core.Messaging.Events"));
            conventions.DefiningMessagesAs(t => t.Namespace != null && t.Namespace.StartsWith("LightSail.Core.Messaging.Messages"));
            conventions.DefiningEncryptedPropertiesAs(p => p.Name.StartsWith("Encrypted"));
            conventions.DefiningDataBusPropertiesAs(p => p.Name.EndsWith("DataBus"));
            conventions.DefiningExpressMessagesAs(t => t.Name.EndsWith("Express"));
            conventions.DefiningTimeToBeReceivedAs(t => t.Name.EndsWith("Expires") ? TimeSpan.FromSeconds(30) : TimeSpan.MaxValue);

            config.RijndaelEncryptionService();
        }
    }
}
