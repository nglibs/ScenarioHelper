using NgLibs.ScenarioHelper.Abstractions;

namespace NgLibs.ScenarioHelper
{
    public class Scenario<TContext> : AbstractScenario<Scenario<TContext>, TContext> where TContext : notnull
    {
    }
}