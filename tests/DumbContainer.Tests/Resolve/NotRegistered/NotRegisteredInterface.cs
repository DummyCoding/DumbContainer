using System;
using FluentAssertions;
using Xunit;

namespace DumbContainer.Tests.Resolve.NotRegistered
{
    public class NotRegisteredInterface
    {
        [Fact]
        public void SimpleClassAsT()
        {
            var dumbContainer = new DumbContainer();

            Action action = () => dumbContainer.Resolve<ITestClass>();

            action.Should().Throw<TryToResolveNotRegisteredTypeException>();
        }

        private interface ITestClass
        {
        }
    }
}