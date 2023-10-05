using UnityEngine;

public class IdleState : State
{
    public IdleState(int maxPriority = 1): base(maxPriority)
    {
        ConcretePriority = maxPriority;
    }

    public override void LogicUpdate()
    {
        Debug.Log("I state");
    }

    public override void PhysicsUpdate(){}

    public override void Enter(){}

    public override void Exit(){}
}