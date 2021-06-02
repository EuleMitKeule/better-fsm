using System;

public abstract class State
{
    public event Action<Type> ChangeRequested;
    protected void SetState<StateType>() where StateType : State
    {
        ChangeRequested?.Invoke(typeof(StateType));
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void DoSomething() { }
    public virtual string ReturnSomething() => "";
}