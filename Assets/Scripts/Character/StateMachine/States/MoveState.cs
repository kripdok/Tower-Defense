using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private MoveSystem _moveSystem;
    private List<Transform> _targets;
    private int _index;

    public MoveState(MoveSystem moveSystem,int maxPriority = 2)
    {
        _moveSystem = moveSystem;
        MaxPriority = maxPriority;
        ConcretePriority = 0;
        _index = 0;
    }

    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void LogicUpdate()
    {
        if (ConcretePriority != 0)
        {
            _moveSystem.Move(_targets[_index]);

            if (_moveSystem.IsReachedTarget)
            {
                IncreaseIndex();
            }
        }
        Debug.Log(_index);
    }

    private void IncreaseIndex()
    {
        _index++;

        if (_index >= _targets.Count)
        {
            ConcretePriority = 0;
        }
    }

    public void GetTarget(List<Transform> targets)
    {
        _targets = targets;
        ConcretePriority = MaxPriority;
        
    }
}