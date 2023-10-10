using UnityEngine;

public class TowerPool : ObjectPool<Tower>
{
    [SerializeField] private TowerFactory _factory;

    public override void Release(Tower tower)
    {
        base.Release(tower);
        tower.TryGetComponent<HealthSystem>(out HealthSystem _health);
        _health.AddMaxHealth();
    }

    protected override Tower CreatePrefab(Tower prefab)
    {
        var obj = _factory.Create(prefab);
        Objects.Add(obj);
        obj.Init(this);
        return obj;

    }
}