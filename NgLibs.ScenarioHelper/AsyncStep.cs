using NgLibs.ScenarioHelper.Abstractions;

namespace NgLibs.ScenarioHelper
{
    public class AsyncStep<TContext> : AsyncAbstractStep<AsyncStep<TContext>, TContext> where TContext : notnull
    {
    }
}