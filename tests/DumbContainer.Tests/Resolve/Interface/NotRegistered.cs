using System;
using FluentAssertions;
using Xunit;

namespace DumbContainer.Tests.Resolve.Interface
{
    public class NotRegistered
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