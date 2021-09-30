using NgLibs.ScenarioHelper.Exceptions;
using NgLibs.ScenarioHelper.Utilities;
using System;
using System.Collections.Generic;

namespace NgLibs.ScenarioHelper.Abstractions
{
    /// <summary>
    /// A context-agnostic container for a list of steps/scenarios to be executed
    /// </summary>
    /// <typeparam name="TScenario"></typeparam>
    /// <typeparam name="TContext"></typeparam>
    public abstract class AbstractScenario<TScenario, TContext> : IInitializeable<ICollection<IExecutable<TContext>>>, IExecutable<TContext>
        where TContext : notnull
        where TScenario : AbstractScenario<TScenario, TContext>, new()
    {
        private ICollection<IExecutable<TContext>>? _executables;


        #region IExecutable<TContext>
        /// <summary>
        /// Executes the scenario for a given context
        /// </summary>
        /// <param name="context">The context used by every step/child scenario of this scenario</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="NotInitializedException" />
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

            foreach (var executable in _executables)
            {
                executable.Execute(context);
            }
        }
        #endregion


        #region IInitializeable
        /// <summary>
        /// </summary>
        /// <param name="initialValue"></param>
        /// <exception cref="AlreadyInitializedException"></exception>
        public void Initialize(ICollection<IExecutable<TContext>> initialValue)
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
        #endregion


        /// <summary>
        /// Start the creation of a scenario. <br/>
        /// This is the first method that should be called when creating a scenario.
        /// </summary>
        /// <returns></returns>
        public static ScenarioBuilder<TScenario, TContext> Begin() => new ScenarioBuilder<TScenario, TContext>();
    }
}