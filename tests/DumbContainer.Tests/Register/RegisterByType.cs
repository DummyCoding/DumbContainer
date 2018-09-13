using System;
using FluentAssertions;
using Xunit;

namespace DumbContainer.Tests.Register
{
    public class RegisterByType
    {
        [Fact]
        public void SimpleClass()
        {
            var dumbContainer = new DumbContainer();

            var testClassType = typeof(TestClass);

            Action register = () => dumbContainer.Register(testClassType, testClassType);

            register.Should().NotThrow();
        }

        private class TestClass
        {
        }
    }
}