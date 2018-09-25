using System;

namespace DumbContainer
{
    public interface IDumbContainer
    {
        object Resolve(Type type);
        T Resolve<T>();

        void Register(Type serviceType, Type implementationType);
        void Register<TService, TImplementation>() where TImplementation : TService;
    }
}