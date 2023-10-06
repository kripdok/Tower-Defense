using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    private List<T> _objects;

    private void Start()
    {
        _objects = new List<T>();
    }

    public T GetPrefab()
    {
        var obj = _objects.FirstOrDefault(obj => obj.isActiveAndEnabled ==false);

        if(obj == null)
        {
            obj = CreatePrefab();
        }

        obj.gameObject.SetActive(true);
        return obj;
    }

    public virtual void Release(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    protected virtual T CreatePrefab()
    {
        var obj = Instantiate(_prefab,transform);
        _objects.Add(obj);
        return obj;
    }
}