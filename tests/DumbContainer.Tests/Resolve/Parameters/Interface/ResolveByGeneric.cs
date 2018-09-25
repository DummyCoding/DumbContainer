using FluentAssertions;
using Xunit;

namespace DumbContainer.Tests.Resolve.Parameters.Interface
{
    public class ResolveByGeneric
    {
        [Fact]
        public void SimpleClassAsT()
        {
            var dumbContainer = new DumbContainer();

            dumbContainer.Register<ITestClass, TestClass>();
            dumbContainer.Register<IInnerTestClass, InnerTestClass>();

            var resolve = dumbContainer.Resolve<ITestClass>();

            resolve.Should().NotBeNull();
            resolve.Should().BeAssignableTo<ITestClass>();

            resolve.InnerTest.Should().NotBeNull();
            resolve.InnerTest.Should().BeAssignableTo<IInnerTestClass>();
        }

        private interface ITestClass
        {
            IInnerTestClass InnerTest { get; }
        }

        private class TestClass : ITestClass
        {
            public TestClass(IInnerTestClass innerTest)
            {
                InnerTest = innerTest;
            }

            public IInnerTestClass InnerTest { get; }
        }

        private interface IInnerTestClass
        {
        }

        private class InnerTestClass : IInnerTestClass
        {
        }
    }
}