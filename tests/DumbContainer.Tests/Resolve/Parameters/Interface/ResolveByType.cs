using FluentAssertions;
using Xunit;

namespace DumbContainer.Tests.Resolve.Parameters.Interface
{
    public class ResolveByType
    {
        [Fact]
        public void SimpleClass()
        {
            var dumbContainer = new DumbContainer();

            var interfaceType = typeof(ITestClass);
            var testClassType = typeof(TestClass);

            var innerInterfaceType = typeof(IInnerTestClass);
            var innerTestClassType = typeof(InnerTestClass);

            dumbContainer.Register(interfaceType, testClassType);
            dumbContainer.Register(innerInterfaceType, innerTestClassType);

            var resolve = dumbContainer.Resolve(interfaceType);

            resolve.Should().NotBeNull();
            resolve.Should().BeAssignableTo(interfaceType);

            ITestClass testClass = (ITestClass)resolve;

            testClass.InnerTest.Should().NotBeNull();
            testClass.InnerTest.Should().BeAssignableTo(innerInterfaceType);
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