using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Archer _archer;
    [SerializeField] private Warrior _warrior;
    [SerializeField] private UnitPool _pool;
    [SerializeField] private List<Transform> _route;
    [SerializeField] private float _delayBetweenSpawn;

    private WaitForSeconds _time;

    private void Start()
    {
        _time = new WaitForSeconds(_delayBetweenSpawn);
        StartCoroutine(spawn());
    }

    private IEnumerator spawn()
    {
        while (true)
        {
            Unit prefab = SelectPrefab();
            var unit = _pool.GetPrefab(prefab);
            unit.transform.position = transform.position;
            unit.Init(_pool, _route);
            yield return _time;
        }
    }

    private Unit SelectPrefab()
    {
        int i = Random.Range(0, 2);

        switch (i)
        {
            case 0:
                return _archer;
            case 1:
                return _warrior;
        }
      
        return null;
    }
}
