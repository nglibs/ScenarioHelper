using System;
using System.Threading.Tasks;
using NgLibs.ScenarioHelper.Exceptions;

namespace NgLibs.ScenarioHelper.Abstractions
{
    public abstract class AsyncAbstractStep<TStep, TContext> : IAsyncExecutable<TContext>
        where TContext : notnull
        where TStep : AsyncAbstractStep<TStep, TContext>, new()
    {
        private Func<TContext, Task>? _asyncAction;

        internal void Initialize(Func<TContext, Task> asyncAction)
        {
            if (_asyncAction is null)
            {
                _asyncAction = asyncAction;
            }
            else
            {
                throw new AlreadyInitializedException();
            }
        }

        public async Task ExecuteAsync(TContext context)
        {
            if (_asyncAction is null)
            {
                throw new NotInitializedException();
            }
            await _asyncAction(context);
        }
        
        public static TStep From(Func<TContext, Task> asyncAction)
        {
            var step = new TStep();
            step.Initialize(asyncAction);
            return step;
        }
    }
}