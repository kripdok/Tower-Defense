using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(HealthSystem))]
[RequireComponent(typeof(UnitStateMachine))]
public class Unit : MonoBehaviour
{
    [SerializeField] private AttackSystem _attackSystem;
    [SerializeField] private float _speed;

    private UnitStateMachine _unitStateMachine;
    private HealthSystem _healthSystem;

    public MoveSystem MoveSystem { get; private set; }
    public RotateSystem RotateSystem { get; private set; }
    public Route Route { get; private set; }

    public AttackSystem AttackSystem => _attackSystem;

    public event UnityAction Died;

    private void Awake()
    {
        _healthSystem= GetComponent<HealthSystem>();
        _unitStateMachine = GetComponent<UnitStateMachine>();
        Route = new Route(_unitStateMachine);
        RotateSystem = new RotateSystem(transform);
        MoveSystem = new MoveSystem(transform, _speed, GetComponent<Rigidbody>(), RotateSystem);
    }

    private void OnEnable()
    {
        _healthSystem.Died += BecomingInactive;
    }

    private void OnDisable()
    {
        _healthSystem.Died += BecomingInactive;
    }

    private void BecomingInactive()
    {
        gameObject.SetActive(false);
        _unitStateMachine.ExitAllStates();
        _healthSystem.AddMaxHealth();
        Died?.Invoke();
    }
}