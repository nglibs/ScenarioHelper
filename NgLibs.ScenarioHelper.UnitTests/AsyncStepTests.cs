using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace NgLibs.ScenarioHelper.UnitTests
{
    public class AsyncStepTests
    {
        [Test]
        public void WhenCreatingTheActionIsNotExecuted()
        {
            // Arrange
            var wasCalled = false;

            // Act
            AsyncStep<Context>.From(async _ =>
           {
               wasCalled = true;
           });

            // Assert
            wasCalled.Should().BeFalse(because: "No execution was triggered.");
        }

        [Test]
        public async Task WhenCreatingAndExecutingTheActionIsExecuted()
        {
            // Arrange
            var wasCalled = false;

            // Act
            await AsyncStep<Context>.From(async _ =>
            {
                wasCalled = true;
            }).ExecuteAsync(new Context());

            // Assert
            wasCalled.Should().BeTrue(because: "The execution was triggered.");
        }
    }
}