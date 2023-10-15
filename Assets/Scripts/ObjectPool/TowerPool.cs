using UnityEngine;

public class TowerPool : ObjectPool<Tower>
{
    [SerializeField] private TowerFactory _factory;

    private void OnEnable()
    {
        EventBus.Instance.ReleasedTower += Release;
    }

    private void OnDisable()
    {
        EventBus.Instance.ReleasedTower -= Release;
    }

    protected override void Release(Tower tower)
    {
        base.Release(tower);
        tower.TryGetComponent<HealthSystem>(out HealthSystem _health);
        _health.AddMaxHealth();
    }

    protected override Tower CreatePrefab(Tower prefab)
    {
        var obj = _factory.Create(prefab);
        Objects.Add(obj);
        return obj;
    }
}