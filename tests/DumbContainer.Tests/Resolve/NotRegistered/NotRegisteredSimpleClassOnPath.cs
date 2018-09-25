using System;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace DumbContainer.Tests.Resolve.NotRegistered
{
    public class NotRegisteredSimpleClassOnPath
    {
        [Fact]
        public void SimpleClassAsT()
        {
            var dumbContainer = new DumbContainer();

            dumbContainer.Register<TestClass, TestClass>();

            Action action = () => dumbContainer.Resolve<ITestClass>();

            action.Should().Throw<TryToResolveNotRegisteredTypeException>();
        }

        private class TestClass
        {
            public TestClass(InnerTestClass innerTest)
            {
                
            }
        }

        private class InnerTestClass
        {
            public InnerTestClass()
            {
                
            }
        }
    }
}