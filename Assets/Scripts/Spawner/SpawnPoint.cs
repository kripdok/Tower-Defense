using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private List<Transform> _route;

    public void Spawning(UnitPool pool,Unit unit)
    {
        unit.transform.position = transform.position;
        unit.Init(pool, _route);
    }

}
