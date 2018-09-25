using System;
using FluentAssertions;
using Xunit;

namespace DumbContainer.Tests.Resolve.SimpleClass
{
    public class NotRegistered
    {
        [Fact]
        public void SimpleClassAsT()
        {
            var dumbContainer = new DumbContainer();

            Action action = () => dumbContainer.Resolve(typeof(TestClass));

            action.Should().Throw<TryToResolveNotRegisteredTypeException>();
        }

        private class TestClass
        {
        }
    }
}