using UnityEngine;

public abstract class AbstractFactory<T>:MonoBehaviour where T : MonoBehaviour
{
    public abstract T Create(T prefab);
}
