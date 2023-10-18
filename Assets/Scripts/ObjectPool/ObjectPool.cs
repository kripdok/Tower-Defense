using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    protected List<T> Objects;

    private void Awake()
    {
        Objects = new List<T>();
    }

    public T GetPrefab(T prefab)
    {
        var obj = Objects.FirstOrDefault(obj => obj.isActiveAndEnabled == false && obj.GetType() == prefab.GetType());

        if (obj == null)
        {
            obj = CreatePrefab(prefab);
        }

        obj.gameObject.SetActive(true);
        return obj;
    }

    protected virtual void Release(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    protected virtual T CreatePrefab(T prefab)
    {
        var obj = Instantiate(prefab, transform);
        Objects.Add(obj);
        return obj;
    }
}