using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class UnitStateMachine : StateMachine
{
    private IdleState _idle;
    public MoveState _move { get; private set; }
    public AttackState _attack { get; private set; }

    private MoveSystem _moveSystem;

    private List<State> _states;


    private void Awake()
    {
        _idle = new IdleState();
        _moveSystem = new MoveSystem(transform,2,GetComponent<Rigidbody>());
        _move = new MoveState(_moveSystem);
        _attack = new AttackState();
        _states = new List<State>()
        {
            _idle, _move, _attack
        };
    }


    private void Update()
    {
        Proverca();
        CorrectState.LogicUpdate();
    }

    private void Proverca()
    {
        int x = 0;

        foreach (var state in _states)
        {
            if (x <= state.ConcretePriority)
            {
                
                x = state.ConcretePriority;
                CorrectState = state;
            }
        }
    }
}
