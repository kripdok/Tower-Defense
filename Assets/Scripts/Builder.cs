using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private Tower _prefab;
    [SerializeField] private TowerPool _pool;

    private Platform _platform;

    private void OnEnable()
    {
        Platform.OnPlatformReady += SetPlatform;
    }

    private void OnDisable()
    {
        Platform.OnPlatformReady -= SetPlatform;
    }

    private void Update()
    {
        if (_platform != null && _prefab != null)
        {
            var obj = _pool.GetPrefab(_prefab);
            _platform.SetTower(obj);
            _platform = null;
        }
    }

    private void SetPlatform(Platform platform)
    {
        _platform = platform;
    }
}