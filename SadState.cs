using System;

public class SadState : State
{
    public override void DoSomething()
    {
        Console.WriteLine("Crying a tear");
        SetState<HappyState>();
    }

    public override string ReturnSomething() => "Very sad";
}