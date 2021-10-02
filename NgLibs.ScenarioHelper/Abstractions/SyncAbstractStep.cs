using NgLibs.ScenarioHelper.Exceptions;
using System;

namespace NgLibs.ScenarioHelper.Abstractions
{
    public abstract class SyncAbstractStep<TStep, TContext> : ISyncExecutable<TContext>
        where TContext : notnull
        where TStep : SyncAbstractStep<TStep, TContext>, new()
    {
        private Action<TContext>? _action;
        
        internal void Initialize(Action<TContext> initialValue)
        {
            if (_action is null)
            {
                _action = initialValue;
            }
            else
            {
                throw new AlreadyInitializedException();
            }
        }

        public void Execute(TContext context)
        {
            if (_action is null)
            {
                throw new NotInitializedException();
            }
            _action(context);
        }
        
        public static TStep From(Action<TContext> action)
        {
            var step = new TStep();
            step.Initialize(action);
            return step;
        }
    }
}