using System;
using FluentAssertions;
using Xunit;

namespace DumbContainer.Tests.Resolve.NotRegistered
{
    public class NotRegisteredInterfaceOnPath
    {
        [Fact]
        public void SimpleClassAsT()
        {
            var dumbContainer = new DumbContainer();

            dumbContainer.Register<ITestClass, TestClass>();

            Action action = () => dumbContainer.Resolve<ITestClass>();

            action.Should().Throw<TryToResolveNotRegisteredTypeException>();
        }

        private interface ITestClass
        {
        }

        private class TestClass : ITestClass
        {
            public TestClass(IInnerTestInterface innerTest)
            {
                
            }
        }

        public interface IInnerTestInterface
        {
            
        }
    }
}