using System;
using System.Collections.Generic;
using System.Linq;

public class Context
{
    State State { get; set; }
    List<State> States { get; }

    public Context()
    {
        States = new()
        {
            new HappyState(),
            new SadState(),  
        };

        SetState<HappyState>();

        Console.WriteLine(ReturnSomething());
        DoSomething();
        Console.WriteLine(ReturnSomething());
        DoSomething();
        Console.WriteLine(ReturnSomething());
        DoSomething();
    }

    void DoSomething() => State?.DoSomething();

    string ReturnSomething() => State?.ReturnSomething();

    void SetState<StateType>() where StateType : State => SetState(typeof(StateType));

    void SetState(Type stateType)
    {
        if (!stateType.IsSubclassOf(typeof(State))) return;

        var nextState = States.Where(e => e.GetType() == stateType).First();
        if (nextState is null) return;

        if (State is not null)
        {
            State?.ExitState();
            State.ChangeRequested -= OnChangeRequested;
        }

        State = nextState;
        State.ChangeRequested += OnChangeRequested;
        State.EnterState();
    }

    void OnChangeRequested(Type stateType) => SetState(stateType);
}