using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerVault : MonoBehaviour
{
    [SerializeField] private List<AbstractTower> _towers;
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private int _upgradePrice;
    [SerializeField] private Sprite _icon;

    private TowerPool _pool;
    private int _correctIndex;
    private AbstractTower _correctTower;

    public string Name => _name;
    public int UpgradePrice => _upgradePrice;
    public int Price => _price;
    public Sprite Icon => _icon;

    public bool IsUpgradeLimitReached => _correctIndex > _towers.Count;

    public UnityAction Died;

    private void Awake()
    {
        _correctIndex = 0;
    }
    public void Init(TowerPool pool)
    {
        _pool = pool;
    }

    public void BuildFirstTower()
    {
        Build(_towers[_correctIndex]);
    }

    public void Upgrade()
    {
        _correctTower.BecomingInactive();
        _correctTower.Died -= BecomingInactive;

        Build(_towers[_correctIndex]);
    }

    public void Sell()
    {
        BecomingInactive();
    }

    private void Build(AbstractTower tower)
    {
        _correctTower = _pool.GetPrefab(tower);
        _correctTower.transform.position = transform.position;
        _correctTower.Died += BecomingInactive;
        TryRaiseIndex();
    }

    private void TryRaiseIndex()
    {
        if(IsUpgradeLimitReached == false)
        {
            _correctIndex++;
        }
    }

    private void BecomingInactive()
    {
        _correctTower.BecomingInactive();
        _correctTower.Died -= BecomingInactive;
        EventBus.Instance.ReleasedVaultTower(this);
        _correctIndex = 0;
    }
}