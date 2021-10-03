using NgLibs.ScenarioHelper.Abstractions;

namespace NgLibs.ScenarioHelper
{
    public class AsyncStep<TContext> : AbstractAsyncStep<AsyncStep<TContext>, TContext> where TContext : notnull
    {
    }
}