using FluentAssertions;
using Xunit;

namespace DumbContainer.Tests.Resolve.Interface
{
    public class ResolveByType
    {
        [Fact]
        public void SimpleClass()
        {
            var dumbContainer = new DumbContainer();

            var interfaceType = typeof(TestClass);
            var testClassType = typeof(TestClass);
            dumbContainer.Register(interfaceType, testClassType);

            object resolve = dumbContainer.Resolve(interfaceType);

            resolve.Should().NotBeNull();
            resolve.Should().BeOfType(interfaceType);
        }

        private interface ITestClass
        {
        }

        private class TestClass : ITestClass
        {
        }
    }
}