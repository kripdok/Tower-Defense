using UnityEngine;
using UnityEngine.Events;

public class Builder : MonoBehaviour
{
    [SerializeField] private TowerPool _pool;

    private Tower _tower;

    public event UnityAction TowerIsBuilt;

    public void TryBuildTowerOnPlatform(Platform platform)
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