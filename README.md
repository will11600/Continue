# Continue

`Continue` is a small .NET library that adds strongly typed state overloads for `Task.ContinueWith` and `CancellationToken.Register`.

Instead of passing state through `object` and casting inside your continuation or callback, you can keep your state type-safe from call site to callback.

## Features

- Strongly typed `ContinueWith` overloads for `Task`
- Strongly typed `ContinueWith` overloads for `Task<TResult>`
- Strongly typed `Register` overloads for `CancellationToken`
- Supports the most common continuation and cancellation overload shapes
- Compatible with modern .NET, .NET Standard, and .NET Framework
- AOT-friendly for supported targets

## Why use it?

The built-in `Task.ContinueWith` and `CancellationToken.Register` APIs accept state as `object`. That works, but it usually means:

- manual casting inside continuation or callback code
- weaker compile-time safety
- less readable call sites

`Continue` keeps the API surface familiar while making the state parameter strongly typed.

## Installation

Install the package from NuGet:

```powershell
dotnet add package Continue
```

Or add it directly to your project file:

```xml
<ItemGroup>
  <PackageReference Include="Continue" Version="3.0.0" />
</ItemGroup>
```

## Supported targets

This package targets:

- .NET 10.0
- .NET Standard 2.1
- .NET Framework 4.8.1

## Quick start

### `Task` continuations

```csharp
using System;
using System.Threading.Tasks;
using WB.Continue;

Task task = Task.CompletedTask;
var state = new RequestContext("demo");

task.ContinueWith(
	static (completedTask, context) =>
	{
		Console.WriteLine($"Status: {completedTask.Status}");
		Console.WriteLine($"Name: {context.Name}");
	},
	state);
```

### `Task<TResult>` continuations

```csharp
using System.Threading.Tasks;
using WB.Continue;

Task<int> task = Task.FromResult(42);
var state = new CalculationState(10);

Task<int> continuation = task.ContinueWith(
	static (completedTask, context) => completedTask.Result + context.Offset,
	state);
```

### `CancellationToken` registration

```csharp
using System;
using System.Threading;
using WB.Continue;

var state = new CancellationContext("operation");
var cts = new CancellationTokenSource();

cts.Token.Register(
	static (context) =>
	{
		Console.WriteLine($"Operation cancelled: {context.Name}");
	},
	state);
```

## Available overloads

`Continue` provides strongly typed overloads for these common patterns:

### Task continuations

- `ContinueWith<TState>(Action<Task, TState>, TState)`
- `ContinueWith<TState>(Action<Task, TState>, TState, CancellationToken)`
- `ContinueWith<TState>(Action<Task, TState>, TState, TaskContinuationOptions)`
- `ContinueWith<TState>(Action<Task, TState>, TState, TaskScheduler)`
- `ContinueWith<TState>(Action<Task, TState>, TState, CancellationToken, TaskContinuationOptions, TaskScheduler)`
- `ContinueWith<TResult, TState>(Func<Task<TResult>, TState, TResult>, TState)`
- `ContinueWith<TResult, TState>(Func<Task<TResult>, TState, TResult>, TState, CancellationToken)`
- `ContinueWith<TResult, TState>(Func<Task<TResult>, TState, TResult>, TState, TaskContinuationOptions)`
- `ContinueWith<TResult, TState>(Func<Task<TResult>, TState, TResult>, TState, TaskScheduler)`
- `ContinueWith<TResult, TState>(Func<Task<TResult>, TState, TResult>, TState, CancellationToken, TaskContinuationOptions, TaskScheduler)`
- `ContinueWith<TResult, TState, TNewResult>(Func<Task<TResult>, TState, TNewResult>, TState)`
- `ContinueWith<TResult, TState, TNewResult>(Func<Task<TResult>, TState, TNewResult>, TState, CancellationToken)`
- `ContinueWith<TResult, TState, TNewResult>(Func<Task<TResult>, TState, TNewResult>, TState, TaskContinuationOptions)`
- `ContinueWith<TResult, TState, TNewResult>(Func<Task<TResult>, TState, TNewResult>, TState, TaskScheduler)`
- `ContinueWith<TResult, TState, TNewResult>(Func<Task<TResult>, TState, TNewResult>, TState, CancellationToken, TaskContinuationOptions, TaskScheduler)`
- `ContinueWith<TResult, TState>(Func<Task, TState, TResult>, TState)`
- `ContinueWith<TResult, TState>(Func<Task, TState, TResult>, TState, CancellationToken)`
- `ContinueWith<TResult, TState>(Func<Task, TState, TResult>, TState, TaskContinuationOptions)`
- `ContinueWith<TResult, TState>(Func<Task, TState, TResult>, TState, TaskScheduler)`
- `ContinueWith<TResult, TState>(Func<Task, TState, TResult>, TState, CancellationToken, TaskContinuationOptions, TaskScheduler)`

### CancellationToken registration

- `Register<TState>(Action<TState, CancellationToken>, TState)` (.NET 6.0+)
- `Register<TState>(Action<TState>, TState)`
- `Register<TState>(Action<TState>, TState, bool useSynchronizationContext)`

## Notes

- `TState` is constrained to reference types, matching the underlying `Task` continuation state model.
- The package is implemented as lightweight extension methods, so there is no runtime service setup or initialization step.

## Building and testing

From the solution root:

```powershell
dotnet build
```

```powershell
dotnet test
```

## License

Licensed under the MIT License.
