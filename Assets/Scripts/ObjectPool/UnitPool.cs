using UnityEngine;
using UnityEngine.Events;

public class UnitPool : ObjectPool<Unit>
{
    [SerializeField] private UnitFactory _factory;

    public event UnityAction UnitDead;

    public override void Release(Unit unit)
    {
        base.Release(unit);
        UnitDead?.Invoke();
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
