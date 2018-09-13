using System;
using FluentAssertions;
using Xunit;

namespace DumbContainer.Tests.Register.Interface
{
    public class RegisterByType
    {
        [Fact]
        public void SimpleClass()
        {
            var dumbContainer = new DumbContainer();

            var interfaceType = typeof(ITestClass);
            var testClassType = typeof(TestClass);

            Action register = () => dumbContainer.Register(interfaceType, testClassType);

            register.Should().NotThrow();
        }

        private interface ITestClass
        {
        }

        private class TestClass : ITestClass
        {
        }
    }
}