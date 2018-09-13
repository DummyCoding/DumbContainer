using System;
using FluentAssertions;
using Xunit;

namespace DumbContainer.Tests.Register.Interface
{
    public class RegisterByGeneric
    {
        [Fact]
        public void SimpleClassAsT()
        {
            var dumbContainer = new DumbContainer();

            Action register = () => dumbContainer.Register<ITestClass, TestClass>();

            register.Should().NotThrow();
        }

        private interface ITestClass
        {
        }

        private class TestClass
        {
        }
    }
}