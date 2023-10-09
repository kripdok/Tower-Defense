using System.Collections.Generic;
using UnityEngine;

public class TowerStateMachine : StateMachine
{
    [SerializeField] private AttackSystem _attackSystem;

    private RotateSystem _rotateSystem;
    private IdleState _idleState;
    public AttackState AttackState { get; private set; }

    private void Awake()
    {
        _idleState = new IdleState(this);
        _rotateSystem = new RotateSystem(transform);
        AttackState = new AttackState(_attackSystem, this);

        States = new List<State>()
        {
            _idleState, AttackState
        };

        SetStateWithTheMaxPriority();
    }
}