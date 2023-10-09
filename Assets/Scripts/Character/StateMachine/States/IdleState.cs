using UnityEngine;

public class IdleState : State
{
    public IdleState(StateMachine stateMachine, int maxPriority = 1): base(maxPriority,stateMachine)
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