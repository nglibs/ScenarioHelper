using NgLibs.ScenarioHelper.Exceptions;
using NgLibs.ScenarioHelper.Utilities;
using System;
using System.Collections.Generic;

namespace NgLibs.ScenarioHelper.Abstractions
{
    public abstract class AbstractSyncScenario<TScenario, TContext> : ISyncExecutable<TContext>
        where TContext : notnull
        where TScenario : AbstractSyncScenario<TScenario, TContext>, new()
    {
        private ICollection<ISyncExecutable<TContext>>? _executables;

        internal void Initialize(ICollection<ISyncExecutable<TContext>> initialValue)
        {
            if (_executables is null)
            {
                _executables = initialValue;
            }
            else
            {
                throw new AlreadyInitializedException();
            }
        }


        protected virtual void ExecuteFirst(TContext context) { }

        public void Execute(TContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (_executables is null)
            {
                throw new NotInitializedException();
            }

            ExecuteFirst(context);
            foreach (var executable in _executables)
            {
                executable.Execute(context);
            }
            ExecuteLast(context);
        }

        protected virtual void ExecuteLast(TContext context) { }

        public static SyncScenarioBuilder<TScenario, TContext> Begin() => new SyncScenarioBuilder<TScenario, TContext>();
    }
}