using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DumbContainer
{
    public class DumbContainer : IDumbContainer
    {
        private readonly Dictionary<Type, Type> _registrations = new Dictionary<Type, Type>();

        public object Resolve(Type type)
        {
            if (!_registrations.TryGetValue(type, out Type registeredType))
            {
                throw ExceptionThrower.ThrowTryToResolveNotRegisteredTypeException(type);    
            }

            ConstructorInfo[] constructorInfos = registeredType.GetConstructors();

            if (constructorInfos.Length > 1)
            {
                throw ExceptionThrower.ThrowTooManyPublicConstructorsOnType(type);
            }

            var parameterInfos = constructorInfos[0].GetParameters();

            if (parameterInfos.Length == 0)
            {
                return Activator.CreateInstance(registeredType);
            }

            object[] createdParameters = 
                parameterInfos
                    .Select(p => Resolve(p.ParameterType))
                    .ToArray();

            return Activator.CreateInstance(registeredType, createdParameters);
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