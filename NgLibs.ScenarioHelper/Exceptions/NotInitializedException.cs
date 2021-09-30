using System;

namespace NgLibs.ScenarioHelper.Exceptions
{
    public class NotInitializedException : Exception
    {
        public NotInitializedException() : base("The initialization method was not called.")
        {
        }
    }
}