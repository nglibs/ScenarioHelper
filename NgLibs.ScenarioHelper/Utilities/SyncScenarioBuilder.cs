using NgLibs.ScenarioHelper.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace NgLibs.ScenarioHelper.Utilities
{
    public sealed class SyncScenarioBuilder<TScenario, TContext>
        where TContext : notnull
        where TScenario : AbstractSyncScenario<TScenario, TContext>, new()
    {
        private readonly ICollection<ISyncExecutable<TContext>> _executables;

        internal SyncScenarioBuilder()
        {
            _executables = new List<ISyncExecutable<TContext>>();
        }

        /// <summary>
        /// Register a step/scenario that should be part of this scenario
        /// </summary>
        /// <param name="syncExecutable"></param>
        /// <returns></returns>
        public SyncScenarioBuilder<TScenario, TContext> Do(ISyncExecutable<TContext> syncExecutable)
        {
            _executables.Add(syncExecutable);
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

    public sealed class AsyncScenarioBuilder<TScenario, TContext>
        where TContext : notnull
        where TScenario : AbstractAsyncScenario<TScenario, TContext>, new()
    {
        private readonly ICollection<IExecutable<TContext>> _executables;

        internal AsyncScenarioBuilder(IEnumerable<IExecutable<TContext>>? executables = null)
        {
            _executables = new List<IExecutable<TContext>>(executables ?? Enumerable.Empty<IExecutable<TContext>>());
        }

        public AsyncScenarioBuilder<TScenario, TContext> Do(IExecutable<TContext> executable)
        {
            _executables.Add(executable);
            return this;
        }

        public TScenario End()
        {
            var scenario = new TScenario();
            scenario.Initialize(_executables);
            return scenario;
        }
    }
}