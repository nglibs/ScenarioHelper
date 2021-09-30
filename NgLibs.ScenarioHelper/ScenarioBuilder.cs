using System.Collections.Generic;

namespace NgLibs.ScenarioHelper
{
    /// <summary>
    /// Utility to build a scenario.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public sealed class ScenarioBuilder<TContext> where TContext : notnull
    {
        private readonly ICollection<IExecutable<TContext>> _executables;

        internal ScenarioBuilder()
        {
            _executables = new List<IExecutable<TContext>>();
        }

        /// <summary>
        /// Register a step/scenario that should be part of this scenario
        /// </summary>
        /// <param name="executable"></param>
        /// <returns></returns>
        public ScenarioBuilder<TContext> Do(IExecutable<TContext> executable)
        {
            _executables.Add(executable);
            return this;
        }

        /// <summary>
        /// Finishes the build process of the scenario. <br/>
        /// This should be the last method to be executed when creating a scenario.
        /// </summary>
        /// <returns></returns>
        public Scenario<TContext> End() => new Scenario<TContext>(_executables);
    }
}