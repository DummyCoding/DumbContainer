using System;

namespace DumbContainer
{
    public static class ExceptionThrower
    {
        public static TryToResolveNotRegisteredTypeException ThrowTryToResolveNotRegisteredTypeException(Type type)
        {
            return new TryToResolveNotRegisteredTypeException($@"You are trying to resolve type {type.Name} that wasn't registered within container.

Please consider using a `Register(Type service, Type implementation)` 
or Register<TService, TImplementation>() method to register type and then resolve.");
        }
    }

    public class TryToResolveNotRegisteredTypeException : Exception
    {
        public TryToResolveNotRegisteredTypeException(string message) : base(message)
        {
        }
    }
}