using System;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace MyConsole.Tests
{
    public class UnitTest1
    {

        [Fact]
        public void TestUsingMockDependency()
        {
            var mockDependency = new Mock<IThingDependency>();

            // set up mock version's method
            mockDependency.Setup(x => x.JoinUpper(It.IsAny<string>(), It.IsAny<string>()))
                .Returns("A B");
                // .Verifiable();

            // set up mock version's property
            mockDependency.Setup(x => x.Meaning)
                .Returns(42);

            // create thing being tested with a mock dependency
            var sut = new ThingBeingTested(mockDependency.Object);

            var result = sut.X();

            // mockDependency.Verify();
            Assert.Equal("A B = 42", result);
        }

        [Fact]
        public void TestUsingMockDependencyUsingInteractionVerification()
        {
            var mockDependency = new Mock<IThingDependency>();
            
            // create thing being tested with a mock dependency
            var sut = new ThingBeingTested(mockDependency.Object)
            {
                FirstName = "Sarah",
                LastName = "Smith"
            };

            var test = sut.X();

            // Assert that the JoinUpper method was called with Sarah Smith
            mockDependency.Verify(x => x.JoinUpper("Sarah", "Smith"), Times.Once);

            // Assert that the Meaning property was accessed once
            mockDependency.Verify(x => x.Meaning, Times.Once);
        }
    }
}
