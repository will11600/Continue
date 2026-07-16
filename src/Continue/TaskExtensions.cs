using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace WB.Continue;

/// <summary>
/// Provides extension methods for the <see cref="Task"/> class to allow for strongly-typed state objects in continuation methods.
/// </summary>
public static class TaskExtensions
{
    /// <typeparam name="TState">The type of the state object passed to the continuation.</typeparam>
    /// <inheritdoc cref="Task.ContinueWith(Action{Task, object}, object, CancellationToken, TaskContinuationOptions, TaskScheduler)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task ContinueWith<TState>(
        this Task task, 
        Action<Task, TState> continuationAction, 
        TState state, 
        CancellationToken cancellationToken, 
        TaskContinuationOptions continuationOptions, 
        TaskScheduler scheduler) 
        where TState : class
    {
        return task.ContinueWith(Unsafe.As<Action<Task, object?>>(continuationAction), 
            state, cancellationToken, continuationOptions, scheduler);
    }

    /// <typeparam name="TState">The type of the state object passed to the continuation.</typeparam>
    /// <inheritdoc cref="Task.ContinueWith(Action{Task, object}, object, TaskScheduler)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task ContinueWith<TState>(
        this Task task, 
        Action<Task, TState> continuationAction, 
        TState state, 
        TaskScheduler scheduler) 
        where TState : class
    {
        return task.ContinueWith(Unsafe.As<Action<Task, object?>>(continuationAction), state, scheduler);
    }

    /// <typeparam name="TState">The type of the state object passed to the continuation.</typeparam>
    /// <inheritdoc cref="Task.ContinueWith(Action{Task, object}, object, TaskContinuationOptions)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task ContinueWith<TState>(
        this Task task, 
        Action<Task, TState> continuationAction, 
        TState state, 
        TaskContinuationOptions continuationOptions) 
        where TState : class
    {
        return task.ContinueWith(Unsafe.As<Action<Task, object?>>(continuationAction), state, continuationOptions);
    }

    /// <typeparam name="TState">The type of the state object passed to the continuation.</typeparam>
    /// <inheritdoc cref="Task.ContinueWith(Action{Task, object}, object, CancellationToken)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task ContinueWith<TState>(
        this Task task, 
        Action<Task, TState> continuationAction, 
        TState state, 
        CancellationToken cancellationToken) 
        where TState : class
    {
        return task.ContinueWith(Unsafe.As<Action<Task, object?>>(continuationAction), state, cancellationToken);
    }

    /// <typeparam name="TState">The type of the state object passed to the continuation.</typeparam>
    /// <inheritdoc cref="Task.ContinueWith(Action{Task, object}, object)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task ContinueWith<TState>(
        this Task task, 
        Action<Task, TState> continuationAction, 
        TState state) 
        where TState : class
    {
        return task.ContinueWith(Unsafe.As<Action<Task, object?>>(continuationAction), state);
    }

    /// <typeparam name="TResult">The type of the result produced by the continuation.</typeparam>
    /// <typeparam name="TState">The type of the state object passed to the continuation.</typeparam>
    /// <inheritdoc cref="Task.ContinueWith{TResult}(Func{Task, object, TResult}, object, TaskScheduler)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task<TResult> ContinueWith<TResult, TState>(
        this Task<TResult> task, 
        Func<Task<TResult>, TState, TResult> continuationFunction, 
        TState state, 
        TaskScheduler scheduler) 
        where TState : class
    {
        return task.ContinueWith(Unsafe.As<Func<Task<TResult>, object?, TResult>>(continuationFunction), state, scheduler);
    }

    /// <typeparam name="TResult">The type of the result produced by the continuation.</typeparam>
    /// <typeparam name="TState">The type of the state object passed to the continuation.</typeparam>
    /// <inheritdoc cref="Task.ContinueWith{TResult}(Func{Task, object, TResult}, object, CancellationToken, TaskContinuationOptions, TaskScheduler)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task<TResult> ContinueWith<TResult, TState>(
        this Task<TResult> task, 
        Func<Task<TResult>, TState, TResult> continuationFunction, 
        TState state, 
        CancellationToken cancellationToken, 
        TaskContinuationOptions continuationOptions, 
        TaskScheduler scheduler) 
        where TState : class
    {
        return task.ContinueWith(Unsafe.As<Func<Task<TResult>, object?, TResult>>(continuationFunction), state, cancellationToken, continuationOptions, scheduler);
    }

    /// <typeparam name="TResult">The type of the result produced by the continuation.</typeparam>
    /// <typeparam name="TState">The type of the state object passed to the continuation.</typeparam>
    /// <inheritdoc cref="Task.ContinueWith{TResult}(Func{Task, object, TResult}, object, CancellationToken)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task<TResult> ContinueWith<TResult, TState>(
        this Task<TResult> task, 
        Func<Task<TResult>, TState, TResult> continuationFunction, 
        TState state, 
        CancellationToken cancellationToken) 
        where TState : class
    {
        return task.ContinueWith(Unsafe.As<Func<Task<TResult>, object?, TResult>>(continuationFunction), state, cancellationToken);
    }

    /// <typeparam name="TResult">The type of the result produced by the continuation.</typeparam>
    /// <typeparam name="TState">The type of the state object passed to the continuation.</typeparam>
    /// <inheritdoc cref="Task.ContinueWith{TResult}(Func{Task, object, TResult}, object, TaskContinuationOptions)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task<TResult> ContinueWith<TResult, TState>(
        this Task<TResult> task, 
        Func<Task<TResult>, TState, TResult> continuationFunction, 
        TState state, 
        TaskContinuationOptions continuationOptions) 
        where TState : class
    {
        return task.ContinueWith(Unsafe.As<Func<Task<TResult>, object?, TResult>>(continuationFunction), state, continuationOptions);
    }

    /// <typeparam name="TResult">The type of the result produced by the continuation.</typeparam>
    /// <typeparam name="TState">The type of the state object passed to the continuation.</typeparam>
    /// <inheritdoc cref="Task.ContinueWith{TResult}(Func{Task, object, TResult}, object)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task<TResult> ContinueWith<TResult, TState>(
        this Task<TResult> task, 
        Func<Task<TResult>, TState, TResult> continuationFunction, 
        TState state) 
        where TState : class
    {
        return task.ContinueWith(Unsafe.As<Func<Task<TResult>, object?, TResult>>(continuationFunction), state);
    }
}
