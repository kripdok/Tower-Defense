using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private UnitPool _pool;
    [SerializeField] private List<Unit> _units;
    [SerializeField] private float _delayBetweenSpawn;

    private WaitForSeconds _time;
    private Coroutine _coroutine;

    private void Awake()
    {
        _time = new WaitForSeconds(_delayBetweenSpawn);
    }

    public void StartWave(int unitCount, List<SpawnPoint> spawnPoints)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        _coroutine = StartCoroutine(Spawning(unitCount, spawnPoints));

    }

    private IEnumerator Spawning(int unitCount, List<SpawnPoint> spawnPoints)
    {
        for(int i = unitCount; i > 0; i--)
        {
            Unit prefab = SelectPrefab();
            var unit = _pool.GetPrefab(prefab);
            var spawn = SelectSpawnPoint(spawnPoints);
            spawn.Spawning(_pool, unit);
            yield return _time;
        }
    }

    private Unit SelectPrefab()
    {
        int i = Random.Range(0, _units.Count);
        return _units[i];
    }

    private SpawnPoint SelectSpawnPoint(List<SpawnPoint> spawnPoints)
    {
        int i = Random.Range(0, spawnPoints.Count);
        return spawnPoints[i];
    }
}