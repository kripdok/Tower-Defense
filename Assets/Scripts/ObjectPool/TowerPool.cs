public class TowerPool : ObjectPool<Tower>
{
    public override void Release(Tower tower)
    {
        base.Release(tower);
        tower.TryGetComponent<HealthSystem>(out HealthSystem _health);
        _health.AddMaxHealth();
    }
}