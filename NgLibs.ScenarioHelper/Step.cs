using NgLibs.ScenarioHelper.Abstractions;

namespace NgLibs.ScenarioHelper
{
    public class Step<TContext> : AbstractStep<Step<TContext>, TContext> where TContext : notnull
    {
    }
}