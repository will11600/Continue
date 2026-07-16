using System;
using System.Collections.Generic;
using System.Threading;

namespace WB.Continue.Tests;

public class CancellationTokenExtensionsTests(CancellationTokenExtensionsTests.Fixture fixture) : 
    IClassFixture<CancellationTokenExtensionsTests.Fixture>
{
    public sealed class Fixture : IDisposable
    {
        public CancellationTokenSource Cts { get; } = new();
        public void Dispose() => Cts.Dispose();
    }

    public sealed class State;

    public static IEnumerable<object[]> RegisterTest1Parameters => [[(Action<State, CancellationToken>)((state, token) => { }), new State()]];

#if NET6_0_OR_GREATER
    [Theory, MemberData(nameof(RegisterTest1Parameters))]
    public void RegisterTest1(
        Action<State, CancellationToken> callback,
        State state)
    {
        fixture.Cts.Token.Register(callback, state);
    }
#endif

    public static IEnumerable<object[]> RegisterTest2Parameters => [[(Action<State>)((state) => { }), new State()]];

    [Theory, MemberData(nameof(RegisterTest2Parameters))]
    public void RegisterTest2(
        Action<State> callback,
        State state)
    {
        fixture.Cts.Token.Register(callback, state);
    }

    public static IEnumerable<object[]> RegisterTest3Parameters => [[(Action<State>)((state) => { }), new State(), true]];

    [Theory, MemberData(nameof(RegisterTest3Parameters))]
    public void RegisterTest3(
        Action<State> callback,
        State state,
        bool useSynchronizationContext)
    {
        fixture.Cts.Token.Register(callback, state, useSynchronizationContext);
    }
}
