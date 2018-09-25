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

        public static Exception ThrowTooManyPublicConstructorsOnType(Type type)
        {
            return new TooManyPublicConstructorsOnTypeException($@"Typ {type.Name} have more then one public constructor. 
Please consider using ony one constructor. Explanation here: https://cuttingedge.it/blogs/steven/pivot/entry.php?id=97");
        }
    }

    public class TryToResolveNotRegisteredTypeException : Exception
    {
        public TryToResolveNotRegisteredTypeException(string message) : base(message)
        {
        }
    }

    public class TooManyPublicConstructorsOnTypeException : Exception
    {
        public TooManyPublicConstructorsOnTypeException(string message) : base(message)
        {
        }
    }
}