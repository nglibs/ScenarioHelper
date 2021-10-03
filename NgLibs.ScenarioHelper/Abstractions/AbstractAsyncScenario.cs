using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NgLibs.ScenarioHelper.Exceptions;
using NgLibs.ScenarioHelper.Utilities;

namespace NgLibs.ScenarioHelper.Abstractions
{
    public abstract class AbstractAsyncScenario<TScenario, TContext> : IAsyncExecutable<TContext>
        where TContext : notnull
        where TScenario : AbstractAsyncScenario<TScenario, TContext>, new()
    {
        private ICollection<IExecutable<TContext>>? _executables;

        internal void Initialize(ICollection<IExecutable<TContext>> executables)
        {
            if (_executables is null)
            {
                _executables = executables;
            }
            else
            {
                throw new AlreadyInitializedException();
            }
        }

        protected virtual Task ExecuteFirst(TContext context) => Task.CompletedTask;

        public async Task ExecuteAsync(TContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (_executables is null)
            {
                throw new NotInitializedException();
            }

            await ExecuteFirst(context);
            foreach (var executable in _executables)
            {
                switch (executable)
                {
                    case IAsyncExecutable<TContext> asyncExecutable:
                        await asyncExecutable.ExecuteAsync(context);
                        break;
                    case ISyncExecutable<TContext> syncExecutable:
                        syncExecutable.Execute(context);
                        break;
                }
            }
            await ExecuteLast(context);
        }

        protected virtual Task ExecuteLast(TContext context) => Task.CompletedTask;

        public static AsyncScenarioBuilder<TScenario, TContext> Begin() => new AsyncScenarioBuilder<TScenario, TContext>();
    }
}