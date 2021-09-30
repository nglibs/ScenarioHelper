using System.Collections.Generic;
using NgLibs.ScenarioHelper.Abstractions;

namespace NgLibs.ScenarioHelper.Utilities
{
    public sealed class ScenarioBuilder<TScenario, TContext>
        where TContext : notnull
        where TScenario : AbstractScenario<TScenario, TContext>, new()
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
        public ScenarioBuilder<TScenario, TContext> Do(IExecutable<TContext> executable)
        {
            _executables.Add(executable);
            return this;
        }

        /// <summary>
        /// Finishes the build process of the scenario. <br/>
        /// This should be the last method to be executed when creating a scenario.
        /// </summary>
        /// <returns></returns>
        public TScenario End()
        {
            var scenario = new TScenario();
            scenario.Initialize(_executables);
            return scenario;
        }
    }
}