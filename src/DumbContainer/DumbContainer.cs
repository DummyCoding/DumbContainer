using System;
using System.Collections.Generic;

namespace DumbContainer
{
    public class DumbContainer : IDumbContainer
    {
        private readonly Dictionary<Type, Type> _registrations = new Dictionary<Type, Type>();

        public object Resolve(Type type)
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>()
        {
            throw new NotImplementedException();
        }

        public void Register(Type serviceType, Type implementationType)
        {
            _registrations[serviceType] = implementationType;
        }

        public void Register<TService, TImplementation>()
        {
            var serviceType = typeof(TService);
            var implementationType = typeof(TImplementation);

            Register(serviceType, implementationType);
        }
    }
}