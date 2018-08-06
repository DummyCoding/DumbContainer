using System;

namespace DumbContainer
{
    public interface IDumbContainer
    {
        object GetInstance(Type type);
        T GetInstance<T>();

        void Register(Type service, Type implementation);
        void Register<TService, TImplementation>();
    }
}