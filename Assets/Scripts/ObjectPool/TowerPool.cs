using UnityEngine;

public class TowerPool : ObjectPool<AbstractTower>
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

    protected override void Release(AbstractTower tower)
    {
        base.Release(tower);
        tower.TryGetComponent<HealthSystem>(out HealthSystem _health);
        _health.AddMaxHealth();
    }

    protected override AbstractTower CreatePrefab(AbstractTower prefab)
    {
        var obj = _factory.Create(prefab);
        Objects.Add(obj);
        return obj;
    }
}