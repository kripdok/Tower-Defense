using UnityEngine;

public class TowerVaultPool : ObjectPool<TowerVault>
{
    [SerializeField] private TowerVaultFactory _factory;
    [SerializeField] private TowerPool _pool;

    private void OnEnable()
    {
        EventBus.Instance.ReleasedVaultTower += Release;
    }

    private void OnDisable()
    {
        EventBus.Instance.ReleasedVaultTower += Release;
    }

    protected override TowerVault CreatePrefab(TowerVault prefab)
    {
        var obj = _factory.Create(prefab);
        obj.Init(_pool);
        Objects.Add(obj);
        return obj;
    }
}