using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private MoveSystem _moveSystem;
    private RotateSystem _rotateSystem;
    private List<Transform> _targets;
    private int _index;

    public MoveState(MoveSystem moveSystem,RotateSystem rotateSystem, int maxPriority = 2) : base(maxPriority)
    {
        _moveSystem = moveSystem;
        _rotateSystem = rotateSystem;
        _index = 0;
    }
    public override void Enter(){}

    public override void LogicUpdate(){}

    public override void PhysicsUpdate()
    {
        _moveSystem.Move(_targets[_index]);
        _rotateSystem.Rotation(_targets[_index]);

        if (_moveSystem.IsReachedTarget)
        {
            IncreaseIndex();
        }
    }
    public override void Exit()
    {
        _moveSystem.Stop();
    }

    public void SetRoute(List<Transform> targets)
    {
        _targets = targets;
        ConcretePriority = MaxPriority;
        Invoke();
    }

    private void IncreaseIndex()
    {
        _index++;

        if (_index >= _targets.Count)
        {
            ConcretePriority = 0;
            Invoke();
        }
    }
}