# ScenarioHelper

## Table of contents

> * [Requirements](#requirements)
> * [Installation](#installation)
> * [Usage](#usage)
>   * [Step](#step)
>   * [Scenario](#scenario)
> * [License](#license)


## About ScenarioHelper
This package was created to help creating, reusing, separating the steps and scenarios in a context-agnostic way, where the context is used only at runtime and not when defining these steps.

## Installation
* From Visual Studio: Project > Manage NuGet Packages > Browse > NgLibs.ScenarioHelper > Install
* From the command line: `dotnet add package NgLibs.ScenarioHelper`

## Usage

### Step

To create a step, you should call the static `From` method from the `Step<TContext>` class and pass as an argument an action which will represent the required step.

E.g.
```cs
var step = Step<ContextType>.From(contextInstance=>{
    // Action based on the context instance
});
```
Usually static classes with static getter-only properties are created that will contain all these steps which will be used in different scenarios.

E.g.
```cs
static class ModuleAbcSteps {
    public Step<ContextType> StepA => Step<ContextType>.From(contextInstance=>{
        // Step A
    });

    public Step<ContextType> StepB => Step<ContextType>.From(contextInstance=>{
        // Step B
    });

    public Step<ContextType> StepC => Step<ContextType>.From(contextInstance=>{
        // Step C
    });
}
```

If majority of the steps have the same context, the Step class can be extended to get rid of the generic type.

E.g.
```cs
class ContextStep : Step<Context>
{
}
```

### Scenario

The creation of a scenario is being done in three steps:

* Initiation, by calling the static method `Begin` from the `Scenarion<TContext>` class
* Definition, by calling the method `Do(executable)` where `executable` can be a step or a scenario for a context of the same type as the type used in Initiation
* Construction, by calling the method `End`, this will build the scenario that can be executed or used in another scenario

 E.g.
```cs
var scenario = Scenario<ContextType>
    .Begin()
    .Do(stepForContextType)
    .Do(anotherScenarioForContextType)
    .End();
```

Usually static classes with static getter-only properties are created that will contain all these scenarios which will be used in different scenarios or executed alone.

E.g.
```cs
static class ModuleAbcScenarios {
    public Scenario<ContextType> ScenarioAbc => Scenario<ContextType>
        .Begin()
        .Do(ModuleAbcSteps.StepA)
        .Do(ModuleAbcSteps.StepB)
        .Do(ModuleAbcSteps.StepC)
        .End();

    public Scenario<ContextType> ScenarioAbcc => Scenario<ContextType>
        .Begin()
        .Do(ModuleAbcScenarios.ScenarioAbc)
        .Do(ModuleAbcSteps.StepC)
        .End();
}
```

To execute a scenario, the method `Execute` should be called and the context instance should be sent as parameter.

E.g.

```cs
scenario.Execute(contextInstance);
```

If majority of the scenarios have the same context, the Scenario class can be extended to get rid of the generic type.

E.g.
```cs
class ContextScenario : Scenario<Context>
{
}
```
### Requirements

See [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet/3.1)


## License

[MIT License](https://opensource.org/licenses/MIT)
