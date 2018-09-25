using FluentAssertions;
using Xunit;

namespace DumbContainer.Tests.Resolve.Parameters.SimpleClass
{
    public class ResolveByType
    {
        [Fact]
        public void SimpleClass()
        {
            var dumbContainer = new DumbContainer();

            var testClassType = typeof(TestClass);

            var innerTestClassType = typeof(InnerTestClass);

            dumbContainer.Register(testClassType, testClassType);
            dumbContainer.Register(innerTestClassType, innerTestClassType);

            var resolve = dumbContainer.Resolve(testClassType);

            resolve.Should().NotBeNull();
            resolve.Should().BeOfType(testClassType);

            TestClass testClass = (TestClass)resolve;

            testClass.InnerTest.Should().NotBeNull();
            testClass.InnerTest.Should().BeOfType(innerTestClassType);
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