using FluentAssertions;
using Xunit;

namespace DumbContainer.Tests.Resolve.Interface
{
    public class ResolveByGeneric
    {
        [Fact]
        public void SimpleClassAsT()
        {
            var dumbContainer = new DumbContainer();

            var interfaceType = typeof(ITestClass);
            var testClassType = typeof(TestClass);
            dumbContainer.Register(interfaceType, testClassType);

            object resolve = dumbContainer.Resolve<ITestClass>();

            resolve.Should().NotBeNull();
            resolve.Should().BeOfType(testClassType);
        }

        private interface ITestClass
        {
        }

        private class TestClass : ITestClass
        {
        }
    }
}