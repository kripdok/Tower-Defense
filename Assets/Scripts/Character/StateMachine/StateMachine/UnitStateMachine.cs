using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class UnitStateMachine : StateMachine
{
    [SerializeField] private float _speed;
    [SerializeField] private AttackSystem _attackSystem;

    private IdleState _idle;
    private MoveSystem _moveSystem;
    private RotateSystem _rotateSystem;
    private List<State> _states;

    public MoveState MoveState { get; private set; }
    public AttackState AttackState { get; private set; }

    private void Awake()
    {
        _idle = new IdleState();
        _moveSystem = new MoveSystem(transform, _speed, GetComponent<Rigidbody>());
        _rotateSystem = new RotateSystem(transform);
        MoveState = new MoveState(_moveSystem, _rotateSystem);
        AttackState = new AttackState(_rotateSystem,_attackSystem);

        _states = new List<State>()
        {
            _idle, MoveState, AttackState
        };

        SetStateWithTheMaxPriority();
    }

    public void OnEnable()
    {
        State.OnPriorityChange += SetStateWithTheMaxPriority;
    }

    public void OnDisable()
    {
        State.OnPriorityChange -= SetStateWithTheMaxPriority;
    }

    private void Update()
    {
        CorrectState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        CorrectState.PhysicsUpdate();
    }

    private void SetStateWithTheMaxPriority()
    {
        State state = _states.OrderByDescending(state => state.ConcretePriority).FirstOrDefault();

        if (CorrectState != null)
        {
            ChangeState(state);
        }
        else
        {
            Initialize(state);
        }
    }
}