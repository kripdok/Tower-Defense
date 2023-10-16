using System.Collections.Generic;
using UnityEngine;


public class UnitStateMachine : StateMachine
{
    [SerializeField] private Unit _unit;

    private IdleState _idleState;

    public MoveState MoveState { get; private set; }
    public AttackState AttackState { get; private set; }

    private void Awake()
    {
        _idleState = new IdleState(this);
        MoveState = new MoveState(_unit.MoveSystem, this);
        AttackState = new AttackState(_unit.AttackSystem, this);

        States = new List<State>()
        {
            _idleState, MoveState, AttackState
        };
        SetStateWithTheMaxPriority();
    }
}