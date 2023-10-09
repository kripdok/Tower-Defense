using UnityEngine;

public class AttackState : State
{
    private AttackSystem _attackSystem;
    private Transform _target;
    private HealthSystem _targetHealth;

    public AttackState(AttackSystem attackSystem,StateMachine stateMachine,int maxPriority = 3) : base(maxPriority, stateMachine)
    {
        _attackSystem = attackSystem;
    }

    public override void Enter()
    {
        _attackSystem.PrepareToStrike(_targetHealth);
    }

    public override void LogicUpdate()
    {
        if(_target == null)
        {
            ConcretePriority = 0;
            StateMachine.SetStateWithTheMaxPriority();
        }
    }

    public override void PhysicsUpdate(){}

    public override void Exit()
    {
        _target = null;
        _attackSystem.TryFinishAttack();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
        _target.TryGetComponent<HealthSystem>(out _targetHealth);
        ConcretePriority = MaxPriority;
        StateMachine.SetStateWithTheMaxPriority();
    }

    public void ClearTarget()
    {
        _target = null;
    }
}