using UnityEngine;
using UnityEngine.Events;

public class Builder : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    [SerializeField] private TowerPool _pool;


    public event UnityAction TowerIsBuilt;

    private void OnEnable()
    {
        Platform.OnPlatformReady += TryBuildTowerOnPlatform;
    }

    private void OnDisable()
    {
        Platform.OnPlatformReady -= TryBuildTowerOnPlatform;
    }

    private void TryBuildTowerOnPlatform(Platform platform)
    {
        if (_tower != null)
        {
            var obj = _pool.GetPrefab(_tower);
            platform.SetTower(obj);
            TowerIsBuilt?.Invoke();
        }
    }

    public void SetTower(Tower tower)
    {
        _tower = tower;
    }
}