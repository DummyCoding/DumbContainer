using System;
using System.Collections.Generic;

namespace DumbContainer
{
    public class DumbContainer : IDumbContainer
    {
        private readonly Dictionary<Type, Type> _registrations = new Dictionary<Type, Type>();

        public object Resolve(Type type)
        {
            var objectTypeToCreate = _registrations[type];

            return Activator.CreateInstance(objectTypeToCreate);
        }

        public T Resolve<T>()
        {
            var objectTypeToCreate = typeof(T);

            return (T)Resolve(objectTypeToCreate);
        }

        public void Register(Type serviceType, Type implementationType)
        {
            _registrations[serviceType] = implementationType;
        }

        public void Register<TService, TImplementation>() where TImplementation : TService
        {
            var serviceType = typeof(TService);
            var implementationType = typeof(TImplementation);

            Register(serviceType, implementationType);
        }
    }
}