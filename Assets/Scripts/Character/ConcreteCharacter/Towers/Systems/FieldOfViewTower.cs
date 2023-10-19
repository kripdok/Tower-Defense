using UnityEngine;

public class FieldOfViewTower : FieldOfView
{
    [SerializeField] private TowerStateMachine _towerStateMachine;

    protected override void ClearTarget()
    {
        _target = null;
        _towerStateMachine.AttackState.ClearTarget();
    }

    protected override void SeeTheTarget(Transform target)
    {
        _target = target;
        _towerStateMachine.AttackState.SetTarget(_target);
    }
}