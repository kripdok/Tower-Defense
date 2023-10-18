using UnityEngine;
using UnityEngine.Events;

public class Builder : MonoBehaviour
{
    [SerializeField] private TowerVaultPool _pool;

    private TowerVault _towerVault;

    public event UnityAction TowerVaultIsBuilt;

    public void TryBuildTowerOnPlatform(Platform platform)
    {
        if (_towerVault != null)
        {
            var obj = _pool.GetPrefab(_towerVault);
            platform.SetTower(obj);
            TowerVaultIsBuilt?.Invoke();
            _towerVault = null;
        }
    }

    public void SetTower(TowerVault towerVault)
    {
        _towerVault = towerVault;
    }
}