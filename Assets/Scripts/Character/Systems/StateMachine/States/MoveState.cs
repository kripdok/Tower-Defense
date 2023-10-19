using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private MoveSystem _moveSystem;
    private List<Transform> _targets;
    private int _index;

    public MoveState(MoveSystem moveSystem, StateMachine stateMachine, int maxPriority = 2) : base(maxPriority,stateMachine)
    {
        _moveSystem = moveSystem;
        _index = 0;
    }
    public override void Enter(){}

    public override void LogicUpdate(){}

    public override void PhysicsUpdate()
    {
        _moveSystem.Move(_targets[_index]);

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
        _index = 0;
        ConcretePriority = MaxPriority;
        StateMachine.SetStateWithTheMaxPriority();
    }

    private void IncreaseIndex()
    {
        _index++;

        if (_index >= _targets.Count)
        {
            ConcretePriority = 0;
            StateMachine.SetStateWithTheMaxPriority();
        }
    }
}