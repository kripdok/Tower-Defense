using UnityEngine;

public class UnitPool : ObjectPool<Unit>
{
    [SerializeField] private UnitFactory _factory;

    public override void Release(Unit unit)
    {
        base.Release(unit);
        unit.TryGetComponent<HealthSystem>(out HealthSystem _health);
        _health.AddMaxHealth();
    }

    protected override Unit CreatePrefab(Unit prefab)
    {
        var obj = _factory.Create(prefab);
        Objects.Add(obj);
        return obj;
    }
}
