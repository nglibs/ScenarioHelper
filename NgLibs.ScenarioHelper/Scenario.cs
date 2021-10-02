using NgLibs.ScenarioHelper.Abstractions;

namespace NgLibs.ScenarioHelper
{
    public class Scenario<TContext> : AbstractSyncScenario<Scenario<TContext>, TContext> where TContext : notnull
    {
    }
}