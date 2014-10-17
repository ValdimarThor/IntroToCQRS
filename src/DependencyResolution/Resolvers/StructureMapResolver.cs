﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using StructureMap;

namespace DependencyResolution.Resolvers
{
    public class StructureMapResolver : IDependencyResolver, IDependencyScope
    {
        private readonly IContainer _container;

        public IDependencyScope BeginScope()
        {
            return new StructureMapResolver(_container.GetNestedContainer());
        }

        public StructureMapResolver(IContainer container)
        {
            if (container == null) throw new ArgumentNullException("container");

            _container = container;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
            {
                return null;
            }

            if (serviceType.IsAbstract || serviceType.IsInterface)
            {
                return _container.TryGetInstance(serviceType);
            }

            return _container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAllInstances(serviceType).Cast<object>();
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}
