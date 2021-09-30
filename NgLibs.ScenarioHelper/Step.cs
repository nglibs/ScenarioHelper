using System;

namespace NgLibs.ScenarioHelper
{
    /// <summary>
    /// A container for a single step which is defined by a action based on a context.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class Step<TContext> : IExecutable<TContext> where TContext : notnull
    {
        private readonly Action<TContext> _action;

        internal Step(Action<TContext> action)
        {
            _action = action;
        }

        /// <summary>
        /// Utility to create a <see cref="Step{TContext}"/> Step from a action.
        /// </summary>
        /// <param name="action">The action to be executed.</param>
        /// <returns>The <see cref="Step{TContext}"/> representing the given action.</returns>
        public static Step<TContext> From(Action<TContext> action) => new Step<TContext>(action);

        public void Execute(TContext context)
        {
            _action(context);
        }
    }
}