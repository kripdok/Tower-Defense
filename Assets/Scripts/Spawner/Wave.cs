using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private UnitPool _unitPool;
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    private int _unitCount = 0;
    private int _correctUnitCount;

    private void Awake()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            spawnPoint.enabled = false;
        }

        EnableSpawnPoint();
        StartNextWawe();
    }

    private void OnEnable()
    {
        _unitPool.UnitDead += ChangeCorrectUnitCount;
    }

    private void OnDisable()
    {
        _unitPool.UnitDead -= ChangeCorrectUnitCount;
    }

    private void StartNextWawe()
    {
        _unitCount++;
        _correctUnitCount = _unitCount;

        if (_unitCount% 5 == 0)
        {
            EnableSpawnPoint();
        }

        var spawns = ReturtnEnableSpawns();
        _spawner.StartWave(_unitCount, spawns);

    }

    private List<SpawnPoint> ReturtnEnableSpawns()
    {
        return _spawnPoints.Where(spawn => spawn.enabled == true).Select(spawn=> spawn).ToList() ;
    } 

    private void EnableSpawnPoint()
    {
        if (_spawnPoints.Any(spawn => spawn.enabled == false))
        {
            var spawn = _spawnPoints.First(spawn => spawn.enabled == false);
            spawn.enabled = true;
        }
    }

    private void ChangeCorrectUnitCount()
    {
        _correctUnitCount--;

        if (_correctUnitCount<= 0)
        {
            StartNextWawe();
        }
    }
}