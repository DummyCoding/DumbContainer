using FluentAssertions;
using Xunit;

namespace DumbContainer.Tests.Resolve
{
    public class ResolveByGeneric
    {
        [Fact]
        public void SimpleClassAsT()
        {
            var dumbContainer = new DumbContainer();

            var testClassType = typeof(TestClass);
            dumbContainer.Register(testClassType, testClassType);

            object resolve = dumbContainer.Resolve<TestClass>();

            resolve.Should().NotBeNull();
            resolve.Should().BeOfType(testClassType);
        }

        private class TestClass
        {
        }
    }
}