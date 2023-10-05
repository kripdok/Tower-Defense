using UnityEngine;

public class AttackState : State
{
    private AttackSystem _attackSystem;
    private RotateSystem _rotateSystem;
    private Transform _target;

    public AttackState(RotateSystem rotateSystem,AttackSystem attackSystem,int maxPriority = 3) : base(maxPriority)
    {
        _rotateSystem = rotateSystem;
        _attackSystem = attackSystem;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
        ConcretePriority = MaxPriority;
    }

    public override void LogicUpdate()
    {
        if (_target != null)
        {
            _rotateSystem.Rotation(_target);
        }
        else
        {
            ConcretePriority = 0;
        }
    }

    public override void PhysicsUpdate(){}

    public override void Enter()
    {
        
        _attackSystem.PrepareToStrike(_target);
    }

    public override void Exit()
    {
        _attackSystem.TryFinishAttack();
    }
}