using UnityEngine;

public class IdleState : State
{
    public IdleState(int maxPriority = 1): base(maxPriority)
    {
        ConcretePriority = maxPriority;
    }
    public override void Enter(){}

    public override void LogicUpdate()
    {
    }

    public override void PhysicsUpdate(){}


    public override void Exit(){}
}