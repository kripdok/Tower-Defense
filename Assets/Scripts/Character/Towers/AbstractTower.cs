using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerStateMachine))]
[RequireComponent(typeof(HealthSystem))]
public abstract class AbstractTower : MonoBehaviour
{
    private StateMachine _stateMachine;
    private HealthSystem _health;

    public event UnityAction Died;

    private void Awake()
    {
        _stateMachine = GetComponent<StateMachine>();
        _health = GetComponent<HealthSystem>();
    }

    private void OnEnable()
    {
        _health.HealthEnded += Die;
    }

    private void OnDisable()
    {
        _health.HealthEnded -= Die;
    }

    public void BecomingInactive()
    {
        _stateMachine.ExitAllStates();
        EventBus.Instance.ReleasedTower?.Invoke(this);
    }

    private void Die()
    {
        Died?.Invoke();
        BecomingInactive();
    }
}