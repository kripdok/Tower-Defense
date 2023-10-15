using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerStateMachine))]
[RequireComponent(typeof(HealthSystem))]
public class Tower : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private int _upgradePrice;
    [SerializeField] private Sprite _icon;
    
    private StateMachine _stateMachine;
    private HealthSystem _health;   

    public bool IsUpgraded { get; private set; }

    public string Name => _name;
    public int UpgradePrice => _upgradePrice;
    public int Price => _price;
    public Sprite Icon => _icon;

    public event UnityAction Died;

    private void Awake()
    {
        _stateMachine = GetComponent<StateMachine>();
        _health = GetComponent<HealthSystem>();
        IsUpgraded = false;
    }

    private void OnEnable()
    {
        _health.HealthEnded += BecomingInactive;
    }

    private void OnDisable()
    {
        _health.HealthEnded -= BecomingInactive;
    }

    public void Upgrade()
    {
        if (IsUpgraded == false) 
        {
            IsUpgraded = true;
        }
    }

    private void BecomingInactive()
    {
        _stateMachine.ExitAllStates();
        IsUpgraded = false;
        EventBus.Instance.ReleasedTower?.Invoke(this);
        Died?.Invoke();
    }
}