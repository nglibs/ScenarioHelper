namespace NgLibs.ScenarioHelper.Abstractions
{
    /// <summary>
    /// Defines an initializeable behavior with a specific context type.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public interface IInitializeable<in TValue>
    {
        void Initialize(TValue initialValue);
    }
}