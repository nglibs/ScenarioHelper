using NgLibs.ScenarioHelper.Abstractions;

namespace NgLibs.ScenarioHelper
{
    public class Step<TContext> : SyncAbstractStep<Step<TContext>, TContext> where TContext : notnull
    {
    }
}