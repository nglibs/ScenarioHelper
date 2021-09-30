using System;
using NgLibs.ScenarioHelper.Exceptions;

namespace NgLibs.ScenarioHelper.Abstractions
{
    /// <summary>
    /// Base class for any step.
    /// A container for a single step which is defined by a action based on a context.
    /// </summary>
    /// <typeparam name="TStep"></typeparam>
    /// <typeparam name="TContext"></typeparam>
    /// <exception cref="NotInitializedException"></exception>
    public abstract class AbstractStep<TStep, TContext> : IInitializeable<Action<TContext>>, IExecutable<TContext>
        where TContext : notnull
        where TStep : AbstractStep<TStep, TContext>, new()
    {
        private Action<TContext>? _action;

        #region IExecutable
        /// <summary>
        /// See <see cref="IExecutable{TContext}.Execute"/>
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotInitializedException"></exception>
        public void Execute(TContext context)
        {
            if (_action is null)
            {
                throw new NotInitializedException();
            }
            _action(context);
        }
        #endregion
        

        #region IInitializeable
        /// <summary>
        /// </summary>
        /// <param name="initialValue"></param>
        /// <exception cref="AlreadyInitializedException"></exception>
        public void Initialize(Action<TContext> initialValue)
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
        #endregion


        /// <summary>
        /// Utility to create a <see cref="Step{TContext}"/> Step from a action.
        /// </summary>
        /// <param name="action">The action to be executed.</param>
        /// <returns>The <see cref="Step{TContext}"/> representing the given action.</returns>
        public static TStep From(Action<TContext> action)
        {
            var step = new TStep();
            step.Initialize(action);
            return step;
        }
    }
}