using System;

public class HappyState : State
{
    public override void DoSomething()
    {
        Console.WriteLine("Laughing loudly");
        SetState<SadState>();
    }

    public override string ReturnSomething() => "So happy";
}