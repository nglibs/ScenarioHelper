using FluentAssertions;
using NUnit.Framework;

namespace NgLibs.ScenarioHelper.UnitTests
{
    public class StepTests
    {
        [Test]
        public void WhenCreatingTheActionIsNotExecuted()
        {
            // Arrange
            var wasCalled = false;

            // Act
            Step<Context>.From(_ =>
            {
                wasCalled = true;
            });

            // Assert
            wasCalled.Should().BeFalse(because: "No execution was triggered.");
        }

        [Test]
        public void WhenCreatingAndExecutingTheActionIsExecuted()
        {
            // Arrange
            var wasCalled = false;

            // Act
            Step<Context>.From(_ =>
            {
                wasCalled = true;
            }).Execute(new Context());

            // Assert
            wasCalled.Should().BeTrue(because: "The execution was triggered.");
        }
    }
}