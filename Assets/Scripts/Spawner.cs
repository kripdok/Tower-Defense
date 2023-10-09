using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ArcherPool _pool;
    [SerializeField] private List<Transform> _route;
    [SerializeField] private float _delayBetweenSpawn;

    private Coroutine _coroutine;
    private WaitForSeconds _time;

    private void Start()
    {
        _time = new WaitForSeconds(_delayBetweenSpawn);
        _coroutine = StartCoroutine(spawn());
    }

    private IEnumerator spawn()
    {
        while (true)
        {
            var unit = _pool.GetPrefab();
            unit.transform.position = transform.position;
            Debug.Log(unit);
            unit.Route.Init(_route);
            yield return _time;
        }
    }
}
