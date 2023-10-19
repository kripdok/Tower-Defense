using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(HealthSystem))]
[RequireComponent(typeof(UnitStateMachine))]
public class Unit : MonoBehaviour
{
    [SerializeField] private int _points;
    [SerializeField] private AttackSystem _attackSystem;
    [SerializeField] private float _speed;

    private Route _route;
    private UnitStateMachine _unitStateMachine;
    private HealthSystem _health;

    public MoveSystem MoveSystem { get; private set; }
    public RotateSystem RotateSystem { get; private set; }

    public AttackSystem AttackSystem => _attackSystem;

    private void Awake()
    {
        _health= GetComponent<HealthSystem>();
        _unitStateMachine = GetComponent<UnitStateMachine>();
        _route = new Route(_unitStateMachine);
        RotateSystem = new RotateSystem(transform);
        MoveSystem = new MoveSystem(transform, _speed, GetComponent<Rigidbody>(), RotateSystem);
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