using FluentAssertions;
using Xunit;

namespace DumbContainer.Tests.Resolve.SimpleClass
{
    public class ResolveByType
    {
        [Fact]
        public void SimpleClass()
        {
            var dumbContainer = new DumbContainer();

            var testClassType = typeof(TestClass);
            dumbContainer.Register(testClassType, testClassType);

            object resolve = dumbContainer.Resolve(testClassType);

            resolve.Should().NotBeNull();
            resolve.Should().BeOfType(testClassType);
        }

        private class TestClass
        {
        }
    }
}