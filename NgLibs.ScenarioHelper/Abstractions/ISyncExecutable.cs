namespace NgLibs.ScenarioHelper.Abstractions
{
    public interface ISyncExecutable<in TContext> : IExecutable<TContext> where TContext : notnull
    {
        /// <summary>
        /// Perform the action of this executable.
        /// </summary>
        /// <param name="context"></param>
        void Execute(TContext context);
    }
}