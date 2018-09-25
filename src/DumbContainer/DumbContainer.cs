using System;
using System.Collections.Generic;

namespace DumbContainer
{
    public class DumbContainer : IDumbContainer
    {
        private readonly Dictionary<Type, Type> _registrations = new Dictionary<Type, Type>();

        public object Resolve(Type type)
        {
            if (_registrations.TryGetValue(type, out Type registeredType))
            {
                return Activator.CreateInstance(registeredType);
            }

            throw ExceptionThrower.ThrowTryToResolveNotRegisteredTypeException(type);
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