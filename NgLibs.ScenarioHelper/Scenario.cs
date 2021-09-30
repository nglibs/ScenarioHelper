using System;
using System.Collections.Generic;

namespace NgLibs.ScenarioHelper
{
    /// <summary>
    /// A context-agnostic container for a list of steps/scenarios to be executed
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class Scenario<TContext> : IExecutable<TContext> where TContext : notnull
    {
        private readonly ICollection<IExecutable<TContext>> _executables;

        /// <summary>
        /// Start the creation of a scenario. <br/>
        /// This is the first method that should be called when creating a scenario.
        /// </summary>
        /// <returns></returns>
        public static ScenarioBuilder<TContext> Begin() => new ScenarioBuilder<TContext>();

        internal Scenario(ICollection<IExecutable<TContext>> executables)
        {
            _executables = executables;
        }

        /// <summary>
        /// Executes the scenario for a given context
        /// </summary>
        /// <param name="context">The context used by every step/child scenario of this scenario</param>
        /// <exception cref="System.ArgumentNullException" />
        public void Execute(TContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            foreach (var executable in _executables)
            {
                executable.Execute(context);
            }
        }
    }
}