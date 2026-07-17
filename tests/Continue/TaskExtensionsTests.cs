using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WB.Continue.Tests;

public class TaskExtensionsTests
{
    [Flags]
    public enum Parameters
    {
        None = 0,
        CancellationToken = 1,
        ContinuationOptions = 1 << 1,
        Scheduler = 1 << 2,
        All = CancellationToken | ContinuationOptions | Scheduler
    }

    public sealed class State;

    public readonly struct Result;

    public readonly struct NewResult;

    [Theory, MemberData(nameof(GatherActionParameters), parameters: Parameters.All)]
    public void ContinueWithTest1(
        Task task,
        Action<Task, State> continuationAction,
        State state,
        CancellationToken cancellationToken,
        TaskContinuationOptions continuationOptions,
        TaskScheduler scheduler)
    {
        task.ContinueWith(continuationAction, state, cancellationToken, continuationOptions, scheduler);
    }

    [Theory, MemberData(nameof(GatherActionParameters), parameters: Parameters.Scheduler)]
    public void ContinueWithTest2(
        Task task,
        Action<Task, State> continuationAction,
        State state,
        TaskScheduler scheduler)
    {
        task.ContinueWith(continuationAction, state, scheduler);
    }

    [Theory, MemberData(nameof(GatherActionParameters), parameters: Parameters.ContinuationOptions)]
    public void ContinueWithTest3(
        Task task,
        Action<Task, State> continuationAction,
        State state,
        TaskContinuationOptions continuationOptions)
    {
        task.ContinueWith(continuationAction, state, continuationOptions);
    }

    [Theory, MemberData(nameof(GatherActionParameters), parameters: Parameters.CancellationToken)]
    public void ContinueWithTest4(
        Task task,
        Action<Task, State> continuationAction,
        State state,
        CancellationToken cancellationToken)
    {
        task.ContinueWith(continuationAction, state, cancellationToken);
    }

    [Theory, MemberData(nameof(GatherActionParameters), parameters: Parameters.None)]
    public void ContinueWithTest5(
        Task task,
        Action<Task, State> continuationAction,
        State state)
    {
        task.ContinueWith(continuationAction, state);
    }

    [Theory, MemberData(nameof(GatherFuncParameters), parameters: Parameters.Scheduler)]
    public void ContinueWithTest6(
        Task<Result> task,
        Func<Task<Result>, State, Result> continuationFunction,
        State state,
        TaskScheduler scheduler)
    {
        task.ContinueWith<Result, State>(continuationFunction, state, scheduler);
    }

    [Theory, MemberData(nameof(GatherFuncParameters), parameters: Parameters.All)]
    public void ContinueWithTest7(
        Task<Result> task,
        Func<Task<Result>, State, Result> continuationAction,
        State state,
        CancellationToken cancellationToken,
        TaskContinuationOptions continuationOptions,
        TaskScheduler scheduler)
    {
        task.ContinueWith<Result, State>(continuationAction, state, cancellationToken, continuationOptions, scheduler);
    }

    [Theory, MemberData(nameof(GatherFuncParameters), parameters: Parameters.CancellationToken)]
    public void ContinueWithTest8(
        Task<Result> task,
        Func<Task<Result>, State, Result> continuationFunction,
        State state,
        CancellationToken cancellationToken)
    {
        task.ContinueWith<Result, State>(continuationFunction, state, cancellationToken);
    }

    [Theory, MemberData(nameof(GatherFuncParameters), parameters: Parameters.ContinuationOptions)]
    public void ContinueWithTest9(
        Task<Result> task,
        Func<Task<Result>, State, Result> continuationFunction,
        State state,
        TaskContinuationOptions continuationOptions)
    {
        task.ContinueWith<Result, State>(continuationFunction, state, continuationOptions);
    }

    [Theory, MemberData(nameof(GatherFuncParameters), parameters: Parameters.None)]
    public void ContinueWithTest10(
        Task<Result> task,
        Func<Task<Result>, State, Result> continuationFunction,
        State state)
    {
        task.ContinueWith<Result, State>(continuationFunction, state);
    }

    [Theory, MemberData(nameof(GatherFuncNewResultParameters), parameters: Parameters.Scheduler)]
    public void ContinueWithTest11(
        Task<Result> task,
        Func<Task<Result>, State, NewResult> continuationFunction,
        State state,
        TaskScheduler scheduler)
    {
        task.ContinueWith(continuationFunction, state, scheduler);
    }

    [Theory, MemberData(nameof(GatherFuncNewResultParameters), parameters: Parameters.All)]
    public void ContinueWithTest12(
        Task<Result> task,
        Func<Task<Result>, State, NewResult> continuationFunction,
        State state,
        CancellationToken cancellationToken,
        TaskContinuationOptions continuationOptions,
        TaskScheduler scheduler)
    {
        task.ContinueWith(continuationFunction, state, cancellationToken, continuationOptions, scheduler);
    }

    [Theory, MemberData(nameof(GatherFuncNewResultParameters), parameters: Parameters.CancellationToken)]
    public void ContinueWithTest13(
        Task<Result> task,
        Func<Task<Result>, State, NewResult> continuationFunction,
        State state,
        CancellationToken cancellationToken)
    {
        task.ContinueWith(continuationFunction, state, cancellationToken);
    }

    [Theory, MemberData(nameof(GatherFuncNewResultParameters), parameters: Parameters.ContinuationOptions)]
    public void ContinueWithTest14(
        Task<Result> task,
        Func<Task<Result>, State, NewResult> continuationFunction,
        State state,
        TaskContinuationOptions continuationOptions)
    {
        task.ContinueWith(continuationFunction, state, continuationOptions);
    }

    [Theory, MemberData(nameof(GatherFuncNewResultParameters), parameters: Parameters.None)]
    public void ContinueWithTest15(
        Task<Result> task,
        Func<Task<Result>, State, NewResult> continuationFunction,
        State state)
    {
        task.ContinueWith(continuationFunction, state);
    }

    [Theory, MemberData(nameof(GatherTaskFuncParameters), parameters: Parameters.All)]
    public void ContinueWithTest16(
        Task task,
        Func<Task, State, Result> continuationFunction,
        State state,
        CancellationToken cancellationToken,
        TaskContinuationOptions continuationOptions,
        TaskScheduler scheduler)
    {
        task.ContinueWith(continuationFunction, state, cancellationToken, continuationOptions, scheduler);
    }

    [Theory, MemberData(nameof(GatherTaskFuncParameters), parameters: Parameters.CancellationToken)]
    public void ContinueWithTest17(
        Task task,
        Func<Task, State, Result> continuationFunction,
        State state,
        CancellationToken cancellationToken)
    {
        task.ContinueWith(continuationFunction, state, cancellationToken);
    }

    [Theory, MemberData(nameof(GatherTaskFuncParameters), parameters: Parameters.ContinuationOptions)]
    public void ContinueWithTest18(
        Task task,
        Func<Task, State, Result> continuationFunction,
        State state,
        TaskContinuationOptions continuationOptions)
    {
        task.ContinueWith(continuationFunction, state, continuationOptions);
    }

    [Theory, MemberData(nameof(GatherTaskFuncParameters), parameters: Parameters.Scheduler)]
    public void ContinueWithTest19(
        Task task,
        Func<Task, State, Result> continuationFunction,
        State state,
        TaskScheduler scheduler)
    {
        task.ContinueWith(continuationFunction, state, scheduler);
    }

    [Theory, MemberData(nameof(GatherTaskFuncParameters), parameters: Parameters.None)]
    public void ContinueWithTest20(
        Task task,
        Func<Task, State, Result> continuationFunction,
        State state)

    {
        task.ContinueWith(continuationFunction, state);
    }

    public static IEnumerable<object> GenerateParameters(Parameters parameters)
    {
        if ((parameters & Parameters.CancellationToken) != 0)
        {
            yield return CancellationToken.None;
        }
        if ((parameters & Parameters.ContinuationOptions) != 0)
        {
            yield return TaskContinuationOptions.None;
        }
        if ((parameters & Parameters.Scheduler) != 0)
        {
            yield return TaskScheduler.Default;
        }
    }

    public static IEnumerable<object[]> GatherActionParameters(Parameters parameters)
    {
        yield return [Task.CompletedTask, (Action<Task, State>)((t, s) => { }), new State(), .. GenerateParameters(parameters)];
    }

    public static IEnumerable<object[]> GatherFuncParameters(Parameters parameters)
    {
        yield return [Task.FromResult(default(Result)), (Func<Task<Result>, State, Result>)((t, s) => default), new State(), .. GenerateParameters(parameters)];
    }

    public static IEnumerable<object[]> GatherFuncNewResultParameters(Parameters parameters)
    {
        yield return [Task.FromResult(default(Result)), (Func<Task<Result>, State, NewResult>)((t, s) => default), new State(), .. GenerateParameters(parameters)];
    }

    public static IEnumerable<object[]> GatherTaskFuncParameters(Parameters parameters)
    {
        yield return [Task.CompletedTask, (Func<Task, State, Result>)((t, s) => default), new State(), .. GenerateParameters(parameters)];
    }
}
