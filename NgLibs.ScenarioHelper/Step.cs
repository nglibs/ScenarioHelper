using NgLibs.ScenarioHelper.Abstractions;

namespace NgLibs.ScenarioHelper
{
    public class Step<TContext> : AbstractSyncStep<Step<TContext>, TContext> where TContext : notnull
    {
    }
}