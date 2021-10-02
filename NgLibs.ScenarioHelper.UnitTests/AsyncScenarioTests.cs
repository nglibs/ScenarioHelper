using FluentAssertions;
using Moq;
using NgLibs.ScenarioHelper.Abstractions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace NgLibs.ScenarioHelper.UnitTests
{
    public class AsyncScenarioTests
    {
        [Test]
        public void WhenCreatingTheExecutableIsNotExecuted()
        {
            // Arrange
            var mockExecutable = new Mock<IAsyncExecutable<Context>>();

            // Act
            AsyncScenario<Context>
                .Begin()
                .Do(mockExecutable.Object)
                .End();

            // Assert
            mockExecutable.Invocations.Count.Should().Be(0, because: "No execution was triggered.");
        }

        [Test]
        public async Task WhenCreatingAndExecutingTheExecutableIsExecuted()
        {
            // Arrange
            var mockExecutable = new Mock<IAsyncExecutable<Context>>();

            // Act
            await AsyncScenario<Context>
                 .Begin()
                 .Do(mockExecutable.Object)
                 .End()
                 .ExecuteAsync(new Context());

            // Assert
            mockExecutable.Invocations.Count.Should().Be(1, because: "The execution was triggered.");
        }

        [Test]
        public void WhenCreatingTheMixedExecutablesAreNotExecuted()
        {
            // Arrange
            var mockSyncExecutable = new Mock<ISyncExecutable<Context>>();
            var mockAsyncExecutable = new Mock<IAsyncExecutable<Context>>();

            // Act
            AsyncScenario<Context>
                .Begin()
                .Do(mockSyncExecutable.Object)
                .Do(mockAsyncExecutable.Object)
                .End();

            // Assert
            mockSyncExecutable.Invocations.Count.Should().Be(0, because: "No execution was triggered.");
            mockAsyncExecutable.Invocations.Count.Should().Be(0, because: "No execution was triggered.");
        }

        [Test]
        public async Task WhenCreatingAndExecutingTheMixedExecutablesAreExecuted()
        {
            // Arrange
            var mockSyncExecutable = new Mock<ISyncExecutable<Context>>();
            var mockAsyncExecutable = new Mock<IAsyncExecutable<Context>>();

            // Act
            await AsyncScenario<Context>
                .Begin()
                .Do(mockSyncExecutable.Object)
                .Do(mockAsyncExecutable.Object)
                .End()
                .ExecuteAsync(new Context());

            // Assert
            mockSyncExecutable.Invocations.Count.Should().Be(1, because: "The execution was triggered.");
            mockAsyncExecutable.Invocations.Count.Should().Be(1, because: "The execution was triggered.");
        }
    }
}