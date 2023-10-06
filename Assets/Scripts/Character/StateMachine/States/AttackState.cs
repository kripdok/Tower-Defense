using UnityEngine;

public class AttackState : State
{
    private AttackSystem _attackSystem;
    private RotateSystem _rotateSystem;
    private Transform _target;
    private HealthSystem _targetHealth;

    public AttackState(RotateSystem rotateSystem,AttackSystem attackSystem,int maxPriority = 3) : base(maxPriority)
    {
        _rotateSystem = rotateSystem;
        _attackSystem = attackSystem;
    }

    public override void Enter()
    {
        _attackSystem.PrepareToStrike(_targetHealth);
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
            Invoke();
        }
    }

    public override void PhysicsUpdate(){}

    public override void Exit()
    {
        _attackSystem.TryFinishAttack();
    }
    public void SetTarget(Transform target)
    {
        _target = target;
        _target.TryGetComponent<HealthSystem>(out _targetHealth);
        ConcretePriority = MaxPriority;
        Invoke();
    }

    public void ClearTarget()
    {
        _target = null;
    }
}