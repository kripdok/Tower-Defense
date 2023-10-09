public class ArcherPool : ObjectPool<Unit>
{
    public override void Release(Unit unit)
    {
        base.Release(unit);
        unit.TryGetComponent<HealthSystem>(out HealthSystem _health);
        _health.AddMaxHealth();
    }
}
