using System;
using FluentAssertions;
using Xunit;

namespace DumbContainer.Tests.Register
{
    public class RegisterByGeneric
    {
        [Fact]
        public void SimpleClassAsT()
        {
            var dumbContainer = new DumbContainer();

            Action register = () => dumbContainer.Register<TestClass, TestClass>();

            register.Should().NotThrow();
        }

        private class TestClass
        {
        }
    }
}