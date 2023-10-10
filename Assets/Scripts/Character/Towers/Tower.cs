using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private HealthSystem _health;
   
    private TowerPool _pool;

    public event UnityAction Died;

    private void OnEnable()
    {
        _health.Died += BecomingInactive;
    }

    private void OnDisable()
    {
        _health.Died += BecomingInactive;
    }

    private void BecomingInactive()
    {
        _stateMachine.ExitAllStates();
        _pool.Release(this);
        Died?.Invoke();
    }

    public void Init(TowerPool pool)
    {
        _pool = pool;
    }
}