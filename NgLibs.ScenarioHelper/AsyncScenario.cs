using NgLibs.ScenarioHelper.Abstractions;

namespace NgLibs.ScenarioHelper
{
    public class AsyncScenario<TContext> : AbstractAsyncScenario<AsyncScenario<TContext>, TContext> where TContext : notnull
    {
    }
}