using UnityEngine;

public class AttackState : State
{
    private AttackSystem _attackSystem;
    private Transform _target;

    public AttackState(AttackSystem attackSystem,StateMachine stateMachine,int maxPriority = 3) : base(maxPriority, stateMachine)
    {
        _attackSystem = attackSystem;
    }

    public override void Enter()
    {
        _attackSystem.PrepareToStrike(_target);
    }

    public override void LogicUpdate()
    {
        if(_target == null)
        {
            Exit();
            StateMachine.SetStateWithTheMaxPriority();
        }
    }

    public override void PhysicsUpdate(){}

    public override void Exit()
    {
        _attackSystem.TryFinishAttack();
        ConcretePriority = 0;
        _target = null;
    }

    public void SetTarget(Transform target)
    {
        Debug.Log("SetTarget");
        _target = target;
        ConcretePriority = MaxPriority;
        StateMachine.SetStateWithTheMaxPriority();
    }

    public void ClearTarget()
    {
        Exit();
    }
}