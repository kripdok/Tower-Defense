using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(HealthSystem))]
[RequireComponent(typeof(UnitStateMachine))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HashUnitAnimation))]
[RequireComponent(typeof(UnitAttack))]
public class Unit : MonoBehaviour
{
    [SerializeField] private int _points;
    [SerializeField] private float _speed;

    private HashUnitAnimation _hashUnitAnimation;
    private UnitStateMachine _unitStateMachine;
    private AttackSystem _attackSystem;
    private HealthSystem _health;
    private Animator _animator;
    private Route _route;

    public RotateSystem RotateSystem { get; private set; }
    public MoveSystem MoveSystem { get; private set; }

    public AttackSystem AttackSystem => _attackSystem;

    private void Awake()
    {
        _hashUnitAnimation = GetComponent<HashUnitAnimation>();
        _unitStateMachine = GetComponent<UnitStateMachine>();
        _attackSystem = GetComponent<UnitAttack>();
        _health= GetComponent<HealthSystem>();
        _animator = GetComponent<Animator>();

        _route = new Route(_unitStateMachine);
        RotateSystem = new RotateSystem(transform);
        MoveSystem = new MoveSystem(transform, _speed, GetComponent<Rigidbody>(), RotateSystem,_animator,_hashUnitAnimation);
    }

    private void OnEnable()
    {
        _health.HealthEnded += BecomingInactive;
    }

    private void OnDisable()
    {
        _health.HealthEnded -= BecomingInactive;
    }

    private void BecomingInactive()
    {
        _unitStateMachine.ExitAllStates();

        EventBus.Instance.ReleasedUnit(this);
        EventBus.Instance.AddPoint.Invoke(_points);
        EventBus.Instance.UnitDied?.Invoke();
    }

    public void Init(UnitPool pool, List<Transform> route)
    {
        _route.Init(route);
    }
}