using UnityEngine;

public class FieldOfViewUnit : FieldOfView
{
    [SerializeField] private Unit _unit;
    [SerializeField] private UnitStateMachine _UnitStateMachine;

    private RotateSystem _rotateSystem;

    private void Start()
    {
        _rotateSystem = _unit.RotateSystem;
    }

    protected override void ClearTarget()
    {
        _target = null;
        _UnitStateMachine.AttackState.ClearTarget();
    }

    protected override void SeeTheTarget(Transform target)
    {
        Debug.Log(target);
        _target = target;
        _rotateSystem.Rotation(_target);
        _UnitStateMachine.AttackState.SetTarget(_target);
    }
}