using System;

namespace NgLibs.ScenarioHelper.Exceptions
{
    public class AlreadyInitializedException : Exception
    {
        public AlreadyInitializedException():base("The initialization method was already called.")
        {
        }
    }
}