using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private MoveSystem _moveSystem;
    private List<Transform> _targets;
    private int _index;

    public MoveState(MoveSystem moveSystem, int maxPriority = 2) : base(maxPriority)
    {
        _moveSystem = moveSystem;
        _index = 0;
    }

    public override void LogicUpdate()
    {

    }

    public override void PhysicsUpdate()
    {
        _moveSystem.Move(_targets[_index]);

        if (_moveSystem.IsReachedTarget)
        {
            IncreaseIndex();
        }
    }

    public void Enter(List<Transform> targets)
    {
        _targets = targets;
        Enter();
    }

    public override void Enter()
    {
        ConcretePriority = MaxPriority;
    }

    private void IncreaseIndex()
    {
        _index++;
        if (_index >= _targets.Count)
        {
            ConcretePriority = 0;
        }
    }
}