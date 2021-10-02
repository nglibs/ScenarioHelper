using FluentAssertions;
using Moq;
using NgLibs.ScenarioHelper.Abstractions;
using NUnit.Framework;

namespace NgLibs.ScenarioHelper.UnitTests
{
    public class ScenarioTests
    {
        [Test]
        public void WhenCreatingTheExecutableIsNotExecuted()
        {
            // Arrange
            var mockExecutable = new Mock<ISyncExecutable<Context>>();

            // Act
            Scenario<Context>
                .Begin()
                .Do(mockExecutable.Object)
                .End();

            // Assert
            mockExecutable.Invocations.Count.Should().Be(0, because: "No execution was triggered.");
        }

        [Test]
        public void WhenCreatingAndExecutingTheExecutableIsExecuted()
        {
            // Arrange
            var mockExecutable = new Mock<ISyncExecutable<Context>>();
            
            // Act
            Scenario<Context>
                .Begin()
                .Do(mockExecutable.Object)
                .End()
                .Execute(new Context());

            // Assert
            mockExecutable.Invocations.Count.Should().Be(1, because: "The execution was triggered.");
        }
    }
}