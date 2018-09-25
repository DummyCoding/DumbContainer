using FluentAssertions;
using Xunit;

namespace DumbContainer.Tests.Resolve.Parameters.SimpleClass
{
    public class ResolveByGeneric
    {
        [Fact]
        public void SimpleClassAsT()
        {
            var dumbContainer = new DumbContainer();

            dumbContainer.Register<TestClass, TestClass>();
            dumbContainer.Register<InnerTestClass, InnerTestClass>();

            var resolve = dumbContainer.Resolve<TestClass>();

            resolve.Should().NotBeNull();
            resolve.Should().BeOfType<TestClass>();

            resolve.InnerTest.Should().NotBeNull();
            resolve.InnerTest.Should().BeOfType<InnerTestClass>();
        }

        private class TestClass
        {
            public TestClass(InnerTestClass innerTest)
            {
                InnerTest = innerTest;
            }

            public InnerTestClass InnerTest { get; }
        }

        private class InnerTestClass
        {
        }
    }
}