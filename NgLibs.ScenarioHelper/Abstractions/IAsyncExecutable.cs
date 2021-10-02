using System.Threading.Tasks;

namespace NgLibs.ScenarioHelper.Abstractions
{
    public interface IAsyncExecutable<in TContext> : IExecutable<TContext> where TContext : notnull
    {
        Task ExecuteAsync(TContext context);
    }
}