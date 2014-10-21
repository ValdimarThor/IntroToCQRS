using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NHibernate.Util;

namespace EventProcessor.NServiceBus.Config
{
    public class EndpointConfigInfo
    {
        private readonly Collection<Type> _handlerTypes = new Collection<Type>();

        public EndpointConfigInfo(string name, IEnumerable<Type> handlerTypes = null)
        {
            Name = name;

            if (handlerTypes != null)
                handlerTypes.ForEach(h => _handlerTypes.Add(h));
        }

        public string Name { get; set; }

        public IEnumerable<Type> HandlerTypes
        {
            get { return _handlerTypes; }
        }
    }
}
