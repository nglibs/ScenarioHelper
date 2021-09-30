namespace NgLibs.ScenarioHelper
{
    /// <summary>
    /// A container for a executable action based on a context.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public interface IExecutable<in TContext> where TContext : notnull
    {
        /// <summary>
        /// Perform the action of this executable.
        /// </summary>
        /// <param name="context"></param>
        void Execute(TContext context);
    }
}